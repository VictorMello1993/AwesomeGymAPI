using AwesomeGym.API.Entidades;
using AwesomeGym.API.Enums;
using AwesomeGym.API.InputModels;
using AwesomeGym.API.Persistence;
using AwesomeGym.API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeGym.API.Controllers
{
    [ApiController]
    [Route("api/alunos")]
    public class AlunosController : ControllerBase
    {
        private readonly AwesomeGymDbContext _awesomeGymDbContext;

        public AlunosController(AwesomeGymDbContext awesomeDbContext)
        {
            _awesomeGymDbContext = awesomeDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var alunos = await _awesomeGymDbContext.Alunos.ToListAsync();
            var alunosViewModel = alunos.Select(a => new AlunoViewModel(a.Nome, a.Status)).ToList();

            return Ok(alunosViewModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var aluno = await _awesomeGymDbContext.Alunos.FirstOrDefaultAsync(u => u.Id == id);

            if (aluno == null)
            {
                return NotFound();
            }

            return Ok(aluno);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AlunoInputModel alunoInputModel)
        {
            var aluno = new Aluno(alunoInputModel.Nome,
                                  alunoInputModel.Endereco, 
                                  alunoInputModel.DataNascimento,
                                  alunoInputModel.IdUnidade,
                                  alunoInputModel.IdProfessor);

            _awesomeGymDbContext.Entry(aluno).State = EntityState.Added;
            await _awesomeGymDbContext.SaveChangesAsync();

            //return Ok();

            //OBS: CreatedAtAction gera uma URL baseada numa action prenchendo a rota e os parâmetros gerados da requisição 
            return CreatedAtAction(nameof(GetById), aluno, new { id = aluno.Id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AlunoUpdateInputModel alunoUpdateInputModel)
        {
            var aluno = await _awesomeGymDbContext.Alunos.FirstOrDefaultAsync(a => a.Id == id);

            if (aluno == null)
            {
                return NotFound();
            }

            aluno.SetNome(alunoUpdateInputModel.Nome);
            aluno.SetEndereco(alunoUpdateInputModel.Endereco);
            aluno.SetDataNascimento(alunoUpdateInputModel.DataNascimento);

            _awesomeGymDbContext.Entry(aluno).State = EntityState.Modified;
            //_awesomeGymDbContext.Update(aluno);

            _awesomeGymDbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var aluno = await _awesomeGymDbContext.Alunos.FirstOrDefaultAsync(a => a.Id == id);

            if (aluno == null)
            {
                return NotFound();
            }

            //_awesomeGymDbContext.Alunos.Remove(aluno);

            aluno.MudarStatus(StatusAlunoEnum.Inativo);
            await _awesomeGymDbContext.SaveChangesAsync();

            return Ok();
        }
    }
}

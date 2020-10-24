using AwesomeGym.API.Entidades;
using AwesomeGym.API.InputModels;
using AwesomeGym.API.Persistence;
using AwesomeGym.API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
        public IActionResult Get()
        {
            var alunos = _awesomeGymDbContext.Alunos.ToList();
            var alunosViewModel = alunos.Select(a => new AlunoViewModel(a.Nome, a.Status)).ToList();

            return Ok(alunosViewModel);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _awesomeGymDbContext.Alunos.FirstOrDefault(u => u.Id == id);

            if (aluno == null)
            {
                return NotFound();
            }

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AlunoInputModel alunoInputModel)
        {
            var aluno = new Aluno(alunoInputModel.Nome,
                                  alunoInputModel.Endereco, 
                                  alunoInputModel.DataNascimento);

            _awesomeGymDbContext.Alunos.Add(aluno);
            _awesomeGymDbContext.SaveChanges();

            //return Ok();

            //OBS: CreatedAtAction gera uma URL baseada numa action prenchendo a rota e os parâmetros gerados da requisição 
            return CreatedAtAction(nameof(GetById), aluno, new { id = aluno.Id });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AlunoUpdateInputModel alunoUpdateInputModel)
        {
            var aluno = _awesomeGymDbContext.Alunos.FirstOrDefault(a => a.Id == id);

            if (aluno == null)
            {
                return NotFound();
            }

            aluno.Endereco = alunoUpdateInputModel.Endereco;

            //_awesomeGymDbContext.Update(aluno);
            _awesomeGymDbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _awesomeGymDbContext.Alunos.FirstOrDefault(a => a.Id == id);

            if (aluno == null)
            {
                return NotFound();
            }

            //_awesomeGymDbContext.Alunos.Remove(aluno);

            aluno.MudarStatusParaInativo();
            _awesomeGymDbContext.SaveChanges();

            return Ok();
        }
    }
}

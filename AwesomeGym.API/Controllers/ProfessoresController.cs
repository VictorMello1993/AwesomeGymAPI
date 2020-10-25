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
    [Route("api/professores")]
    public class ProfessoresController : ControllerBase
    {
        private readonly AwesomeGymDbContext _awesomeGymDbContext;

        public ProfessoresController(AwesomeGymDbContext awesomeDbContext)
        {
            _awesomeGymDbContext = awesomeDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var professores = await _awesomeGymDbContext.Professores.ToListAsync();
            var professoresViewModel = professores.Select(p => new ProfessorViewModel(p.Nome, p.Status)).ToList();

            return Ok(professoresViewModel);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var professor = await _awesomeGymDbContext.Professores.FirstOrDefaultAsync(p => p.Id == id);

            if(professor == null)
            {
                return NotFound();
            }

            return Ok(professor);
        }

        [HttpPost]
        public async Task <IActionResult> Post([FromBody]ProfessorInputModel professorInputModel)
        {
            var professor = new Professor(professorInputModel.Nome, 
                                          professorInputModel.Endereco, 
                                          professorInputModel.IdUnidade);

            _awesomeGymDbContext.Entry(professor).State = EntityState.Added;
            await _awesomeGymDbContext.SaveChangesAsync();
            
            //return Ok();
            return CreatedAtAction(nameof(GetById), professor, new { id = professor.Id });
        }

        [HttpPut("{id}")] 
        public async Task<IActionResult> Put(int id, [FromBody] ProfessorUpdateInputModel professorUpdateInputModel)
        {
            var professor = await _awesomeGymDbContext.Professores.FirstOrDefaultAsync(p => p.Id == id);

            if(professor == null)
            {
                return NotFound();
            }

            professor.SetNome(professorUpdateInputModel.Nome);
            professor.SetEndereco(professorUpdateInputModel.Endereco);

            _awesomeGymDbContext.Entry(professor).State = EntityState.Modified;
            await _awesomeGymDbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var professor = await _awesomeGymDbContext.Professores.FirstOrDefaultAsync(p => p.Id == id);

            if(professor == null)
            {
                return NotFound();
            }

            professor.mudarStatus(StatusProfessorEnum.Inativo);
            await _awesomeGymDbContext.SaveChangesAsync();

            return Ok();
        }
    }
}

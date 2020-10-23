using AwesomeGym.API.Entidades;
using AwesomeGym.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public IActionResult Get()
        {
            var professores = _awesomeGymDbContext.Professores.ToList();

            return Ok(professores);
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var professor = _awesomeGymDbContext.Professores.FirstOrDefault(p => p.Id == id);

            if(professor == null)
            {
                return NotFound();
            }

            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Professor professor)
        {
            //var unidade = new Unidade("unidade1", "und_endereco1");
            //professor.IdUnidade = unidade.Id;
            //_awesomeGymDbContext.Unidades.Add(unidade);
            //_awesomeGymDbContext.SaveChanges();

            _awesomeGymDbContext.Professores.Add(professor);
            _awesomeGymDbContext.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")] 
        public IActionResult Put(int id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}

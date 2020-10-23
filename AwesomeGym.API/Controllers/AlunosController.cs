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

            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var aluno = _awesomeGymDbContext.Alunos.FirstOrDefault(u => u.Id == id);

            if(aluno == null)
            {
                return NotFound();
            }

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Aluno aluno)
        {
            //Chumbando professor para fins de testes
            var professor = new Professor("professor1", "endereco 1", aluno.IdUnidade);
            _awesomeGymDbContext.Professores.Add(professor);
            _awesomeGymDbContext.SaveChanges();

            _awesomeGymDbContext.Alunos.Add(aluno);
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
            return Delete(id);
        }
    }
}

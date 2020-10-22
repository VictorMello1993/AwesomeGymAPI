using AwesomeGym.API.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeGym.API.Controllers
{
    [ApiController]
    [Route("api/unidades")]
    public class UnidadesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new List<Aluno> {
                new Aluno("Victor", "Rua Zero", DateTime.Now),
                new Aluno("Victor 2", "Rua Zero", DateTime.Now),
                new Aluno("Victor 3", "Rua Zero", DateTime.Now)
            });
        }

        [HttpGet("{id}")] //Obtendo apenas uma unidade
        public IActionResult Get(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }
        
        [HttpPut("{id}")] //Inserindo ou atualizando uma unidade
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

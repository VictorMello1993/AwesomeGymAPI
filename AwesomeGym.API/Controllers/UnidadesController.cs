using AwesomeGym.API.Entidades;
using AwesomeGym.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly AwesomeGymDbContext _awesomeGymDbContext;

        public UnidadesController(AwesomeGymDbContext awesomeDbContext)
        {
            _awesomeGymDbContext = awesomeDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var unidades = _awesomeGymDbContext.Unidades.ToList();
            return Ok(unidades);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var unidade = _awesomeGymDbContext.Unidades.FirstOrDefault(u => u.Id == id);

            if (unidade == null)
            {
                return NotFound();
            }

            return Ok(unidade);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Unidade unidade)
        {
            _awesomeGymDbContext.Unidades.Add(unidade);

            _awesomeGymDbContext.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Unidade unidade)
        {
            //Modo síncrono
            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------            
            //if (!_awesomeGymDbContext.Unidades.Any(u => u.Id == id))
            //{
            //    return NotFound();
            //}
            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            //Modo assíncrono
            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            if (!(await _awesomeGymDbContext.Unidades.AnyAsync(u => u.Id == id)))
            {
                return NotFound();
            }
            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            //Modo síncrono
            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //_awesomeGymDbContext.Unidades.Update(unidade);
            //_awesomeGymDbContext.SaveChanges();
            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            //Modo assíncrono
            _awesomeGymDbContext.Entry(unidade).State = EntityState.Modified;

            return Ok();
        }
    }
}

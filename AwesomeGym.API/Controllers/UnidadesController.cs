using AwesomeGym.API.Entidades;
using AwesomeGym.API.InputModels;
using AwesomeGym.API.Persistence;
using AwesomeGym.API.ViewModels;
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
        public async Task<IActionResult> Get()
        {
            var unidades = await _awesomeGymDbContext.Unidades.ToListAsync();
            var unidadesViewModel = unidades.Select(u => new UnidadeViewModel(u.Nome)).ToList();

            return Ok(unidades);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var unidade = await _awesomeGymDbContext.Unidades.FirstOrDefaultAsync(u => u.Id == id);

            if (unidade == null)
            {
                return NotFound();
            }

            return Ok(unidade);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UnidadeInputModel unidadeInputModel)
        {
            var unidade = new Unidade(unidadeInputModel.Nome, unidadeInputModel.Endereco);

            //_awesomeGymDbContext.Unidades.Add(unidade);

            _awesomeGymDbContext.Entry(unidade).State = EntityState.Added;
            await _awesomeGymDbContext.SaveChangesAsync();

            //return Ok();
            
            return CreatedAtAction(nameof(GetById), unidade, new { id = unidade.Id});
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UnidadeUpdateInputModel unidadeUpdateInputModel)
        {
            var unidade = await _awesomeGymDbContext.Unidades.FirstOrDefaultAsync(u => u.Id == id);
            //Modo síncrono
            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------            
            //if (!_awesomeGymDbContext.Unidades.Any(u => u.Id == id))
            //{
            //    return NotFound();
            //}
            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            //Modo assíncrono
            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            if (unidade == null)
            {
                return NotFound();
            }

            unidade.SetNome(unidadeUpdateInputModel.Nome);
            unidade.SetEndereco(unidadeUpdateInputModel.Endereco);

            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            //Modo síncrono
            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //_awesomeGymDbContext.Unidades.Update(unidade);
            //_awesomeGymDbContext.SaveChanges();
            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            //Modo assíncrono
            _awesomeGymDbContext.Entry(unidade).State = EntityState.Modified;
            await _awesomeGymDbContext.SaveChangesAsync();

            return Ok();
        }
    }
}

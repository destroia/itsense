using itsense.Data.Interface;
using itsense.Models;
using itsense.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace itsense.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntradasController : ControllerBase
    {
        readonly IEntrada Repo;
        public EntradasController(IEntrada repo)
        {
            Repo = repo;
        }
        // GET: api/<EntradasController>
        [HttpGet]
        public async Task<IEnumerable<EntradaAndSalidaDto>> Get()
        {
            return await Repo.Get();
        }

       
        // POST api/<EntradasController>
        [HttpPost]
        public async Task<ActionResult<bool>> Post(Entrada entrada)
        {
            if (!ModelState.IsValid)
	        {
                return BadRequest(ModelState);
	        }
            bool result = await Repo.Create(entrada);

            return result == true ? Ok(result) : BadRequest(result);
        }

        // PUT api/<EntradasController>/
        [HttpPut]
        public async Task<ActionResult<bool>> Put(Entrada entrada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool result = await Repo.Update(entrada);

            return result == true ? Ok(result) : BadRequest(result);
        }

        // DELETE api/<EntradasController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>>  Delete(int id)
        {
            var result = await Repo.Delete(id);

            return result == true ? Ok(result) : BadRequest(result);
        }
    }
}

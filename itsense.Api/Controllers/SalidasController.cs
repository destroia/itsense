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
    public class SalidasController : ControllerBase
    {
        readonly ISalida Repo;
        public SalidasController(ISalida repo)
        {
            Repo = repo;
        }
        // GET: api/<SalidasController>
        [HttpGet]
        public async Task<ActionResult<List<EntradaAndSalidaDto>>> Get()
        {
            return await Repo.Get();
        }


        // POST api/<SalidasController>
        [HttpPost]
        public async Task<ActionResult<bool>> Post(Salida salida)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool result = await Repo.Create(salida);

            return result == true ? Ok(result) : BadRequest(result);
        }

        // PUT api/<SalidasController>/5
        [HttpPut]
        public async Task<ActionResult<bool>> Put(Salida salida)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool result = await Repo.Update(salida);

            return result == true ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var result = await Repo.Delete(id);

            return result == true ? Ok(result) : BadRequest(result);
        }
    }
}

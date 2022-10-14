using itsense.Data.Interface;
using itsense.Models;
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
    public class ProductosController : ControllerBase
    {
        readonly IProducto Repo;
        public ProductosController(IProducto repo)
        {
            Repo = repo;
        }
        // GET: api/<ProductosController>
        [HttpGet]
        public async Task<ActionResult<List<Producto>>>  Get()
        {
            return await Repo.Get();
        }

        // POST api/<ProductosController>
        [HttpPost]
        public async Task<ActionResult<bool>> Post(Producto pro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool result = await Repo.Create(pro);

            return result == true ? Ok(result) : BadRequest(result);
        }

        // PUT api/<ProductosController>/5
        [HttpPut]
        public async Task<ActionResult<bool>> Put(Producto pro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool result = await Repo.Update(pro);

            return result == true ? Ok(result) : BadRequest(result);
        }
    }
}

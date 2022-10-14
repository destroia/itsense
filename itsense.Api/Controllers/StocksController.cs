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
    public class StocksController : ControllerBase
    {
        readonly IStock Repo;
        public StocksController(IStock repo)
        {
            Repo = repo;
        }
        // GET: api/<StocksController>
        [HttpGet]
        public async Task<ActionResult<List<Stock>>> Get()
        {
            return await Repo.Get();
        }


        // POST api/<StocksController>
        [HttpPost]
        public async Task<ActionResult<bool>> Post(Stock Stock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool result = await Repo.Create(Stock);

            return result == true ? Ok(result) : BadRequest(result);
        }

        // PUT api/<StocksController>/5
        [HttpPut]
        public async Task<ActionResult<bool>> Put(Stock stock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool result = await Repo.Update(stock);

            return result == true ? Ok(result) : BadRequest(result);
        }
    }
}

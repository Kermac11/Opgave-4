using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ModelLib;
using RestfulServer.Managers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestfulServer.Controllers
{
    [Route("api/LocalFootballer")]
    [ApiController]
    public class FootballController : ControllerBase
    {
        private readonly IManageFootball mgr = new ManageFootball();
        // GET: api/<ItemsController>
        [HttpGet]
        public IEnumerable<FootballPlayer> Get()
        {
            return mgr.Get();
        }

        // GET api/<ItemsController>/5
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(mgr.Get(id));
            }
            catch (KeyNotFoundException knfe)
            {
               return NotFound(knfe.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        // POST api/<ItemsController>
        [HttpPost]
        public bool Post([FromBody] FootballPlayer value)
        {
            return mgr.Create(value);
        }

        // PUT api/<ItemsController>/5
        [HttpPut]
        [Route("{id}")]
        public bool Put(int id, [FromBody] FootballPlayer value)
        {
            return mgr.Update(id, value);
        }

        // DELETE api/<ItemsController>/5
        [HttpDelete]
        [Route("{id}")]
        public FootballPlayer Delete(int id)
        {
            return mgr.Delete(id);
        }
    }
}

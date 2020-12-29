using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Checkout.Core.DB;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Checkout.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckOut : ControllerBase
    {
        // GET: api/<CheckOut>
        [HttpGet]
        public IEnumerable<string> Get()
        {
             
            return new string[] { "value1", "value2" };
        }

        // GET api/<CheckOut>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CheckOut>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CheckOut>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CheckOut>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

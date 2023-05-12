using B0L3FV_HFT_2022232.Logic;
using B0L3FV_HFT_2022232.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace B0L3FV_HFT_2022232.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoblinController : ControllerBase
    {

        IGoblinLogic logic;

        public GoblinController(IGoblinLogic logic)
        {
            this.logic = logic;
        }






        [HttpGet]
        //public IEnumerable<string> ReadAll()
        //{
        //    //return this.logic.ReadAll();
        //}

        // GET api/<GoblinController>/5
        [HttpGet("{id}")]
        public Goblin Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<GoblinController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GoblinController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GoblinController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

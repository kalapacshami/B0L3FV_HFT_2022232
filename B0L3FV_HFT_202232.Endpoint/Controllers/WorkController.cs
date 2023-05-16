using B0L3FV_HFT_2022232.Logic;
using B0L3FV_HFT_2022232.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;



namespace B0L3FV_HFT_2022232.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {

        IWorkLogic logic;

        public WorkController(IWorkLogic logic)
        {
            this.logic = logic;
        }


        // GET: api/<WorkController>
        [HttpGet]
        public IEnumerable<Work> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<WorkController>/5
        [HttpGet("{id}")]
        public Work Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<WorkController>
        [HttpPost]
        public void Post([FromBody] Work value)
        {
            this.logic.Create(value);
        }

        // PUT api/<WorkController>/5
        [HttpPut]
        public void Update( [FromBody] Work value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<WorkController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}

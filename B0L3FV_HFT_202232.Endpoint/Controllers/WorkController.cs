using B0L3FV_HFT_2022232.Endpoint.Services;
using B0L3FV_HFT_2022232.Logic;
using B0L3FV_HFT_2022232.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;



namespace B0L3FV_HFT_2022232.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {

        IWorkLogic logic;
        IHubContext<SignalRHub> hub;
        public WorkController(IWorkLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("WorkCreated", value);
        }

        // PUT api/<WorkController>/5
        [HttpPut]
        public void Update( [FromBody] Work value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("WorkUpdated", value);
        }

        // DELETE api/<WorkController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var workToDelete = this.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("WorkDeleted", workToDelete);
        }
    }
}

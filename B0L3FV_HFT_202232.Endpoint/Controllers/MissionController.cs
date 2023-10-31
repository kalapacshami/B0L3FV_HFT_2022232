using B0L3FV_HFT_2022232.Endpoint.Services;
using B0L3FV_HFT_2022232.Logic;
using B0L3FV_HFT_2022232.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Reflection;



namespace B0L3FV_HFT_2022232.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MissionController : ControllerBase
    {

        IMissionLogic logic;
        IHubContext<SignalRHub> hub;
        public MissionController(IMissionLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }


        // GET: api/<MissionController>
        [HttpGet]
        public IEnumerable<Mission> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<MissionController>/5
        [HttpGet("{id}")]
        public Mission Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<MissionController>
        [HttpPost]
        public void Create([FromBody] Mission value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("MissionCreated", value);
        }

        // PUT api/<MissionController>/5
        [HttpPut]
        public void Update([FromBody] Mission value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("MissionUpdated", value);
        }

        // DELETE api/<MissionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var missionToDelete= this.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("MissionDeleted", missionToDelete);

        }
    }
}

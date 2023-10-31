using B0L3FV_HFT_2022232.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static B0L3FV_HFT_2022232.Logic.MissionLogic;



namespace B0L3FV_HFT_2022232.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ToolController : ControllerBase
    {

        IMissionLogic logic;

        public ToolController(IMissionLogic logic)
        {
            this.logic = logic;
        }


        [HttpGet]
        public IEnumerable<Tool1> AVGMission()
        {
            return logic.AVGMission(); 
            
        }

        [HttpGet]
        public IEnumerable<Tool2> Missions()
        {
            return logic.Missions();
        }

        [HttpGet]
        public IEnumerable<Tool3> AVGWork()
        {
            return logic.AVGWork();
        }
        [HttpGet]
        public IEnumerable<Tool4> AVGGoblin()
        {
            return logic.AVGGoblin();
        }
        [HttpGet]
        public IEnumerable<Tool5> KillCountMissions()
        {
            return logic.KillCountMissions();
        }

    }
}

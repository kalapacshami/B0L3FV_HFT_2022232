using B0L3FV_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static B0L3FV_HFT_2022232.Logic.MissionLogic;

namespace B0L3FV_HFT_2022232.Logic
{
    public interface IMissionLogic
    {
        void Create(Mission item);
        void Delete(int id);

        Mission Read(int id);
        IQueryable<Mission> ReadAll();
        void Update(Mission item);

        public IEnumerable<Tool1> AVGMission();
        public IEnumerable<Tool2> Missions();
        public IEnumerable<Tool3> AVGWork();
        public IEnumerable<Tool4> AVGGoblin();
        public IEnumerable<Tool5> KillCountMissions();

    }
}

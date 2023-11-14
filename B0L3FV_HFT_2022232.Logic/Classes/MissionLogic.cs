using B0L3FV_HFT_2022232.Models;
using B0L3FV_HFT_2022232.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace B0L3FV_HFT_2022232.Logic
{
    public class MissionLogic : IMissionLogic
    {
        IRepository<Mission> repo;

        public MissionLogic(IRepository<Mission> repo)
        {
            this.repo = repo;
        }
        public void Create(Mission item)
        {
            if (item.MType.Length < 4)
            {
                throw new ArgumentException("Too short for the type of the mission");
            }
            else if (item.MType.Length > 100)
            {
                throw new ArgumentException("Too long for the mission type");
            }
            else if (item.Location.Length < 4)
            {
                throw new ArgumentException("Too short for the location");
            }
            else if (item.Location.Length > 100)
            {
                throw new ArgumentException("Too long for the location");
            }
            else if (item.Hazard >=6)
            {
                throw new ArgumentException("Hazard status can only be between 0 or 5");
            }
            else
            {
                repo.Create(item);
            }

        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Mission Read(int id)
        {
            return repo.Read(id);
        }

        public IQueryable<Mission> ReadAll()
        {
            return repo.ReadAll();
        }

        
        public void Update(Mission item)
        {
            repo.Update(item);
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------

        public IEnumerable<Tool1> AVGMission() 
        {
            return (from x in repo.ReadAll().ToList()
                     group x by x.MType into g
                     select new Tool1
                     {
                         type = g.Key,
                         avg_loot = g.Average(t => t.Loot),
                         avg_level = g.Average(t => t.Goblin.Level),
                         avg_Height = g.Average(t => t.Goblin.Height),
                         avg_Hazard = g.Average(t => t.Hazard)
                     }).AsEnumerable<Tool1>();
        }
        public IEnumerable<Tool2> Missions() 
        {
            var mis = from x in repo.ReadAll()
                      select new Tool2 {
                      Name=x.Goblin.Work.WName,
                      Type=x.MType,
                      Id=x.MissionID
                      };
            return mis;
        
        }
        public IEnumerable<Tool3> AVGWork()
        {
            return (from x in repo.ReadAll().ToList()
                    group x by x.Goblin.Work.WID into g
                    select new Tool3
                    {
                        Name=g.Select(t=>t.Goblin.Work.WName).First(),
                        Income = g.Average(t=>t.Goblin.Money),
                        Height=g.Average(t=>t.Goblin.Height),
                        Hazard=g.Average(t=>t.Hazard)
                        
                    }).AsEnumerable<Tool3>();
        }
        public IEnumerable<Tool4> AVGGoblin()
        {
            return from x in repo.ReadAll()
                    group x by x.Goblin.GoblinName into g
                    select new Tool4
                    {
                        Name = g.Key,
                        Loot=g.Average(t=>t.Loot),
                        Kill= g.Average(t => t.Kills),
                        Death = g.Average(t => t.Deaths),
                        Duration=g.Average(t => t.MissionDuration)
                    };
        }
        public IEnumerable<Tool5> KillCountMissions()
        {
            return from x in repo.ReadAll()
                   where x.Kills > 100
                   select new Tool5 {
                   Id=x.MissionID,
                   Type=x.MType,
                   Name=x.Goblin.GoblinName,
                   Kill=x.Kills,
                   Goblin_work=x.Goblin.Work.WName
                   };
                   
        }



        




    }

  
}

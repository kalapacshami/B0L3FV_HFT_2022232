using B0L3FV_HFT_2022232.Models;
using B0L3FV_HFT_2022232.Repository;
using System;
using System.Collections.Generic;
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

        }
        public IEnumerable<Tool5> KillCountMissions()
        {

        }



        // for the avg mission non-crud method
        public class Tool1 
        {
            public string type { get; set; }
            public double avg_loot { get; set; }
            public double avg_level { get; set;}
            public double avg_Height { get; set; }
            public double avg_Hazard { get; set;}

            public override bool Equals(object obj)
            {
                Tool1 other = obj as Tool1;
                if (other == null) 
                {
                    return false; 
                }
                else
                {
                    return type==other.type && avg_loot==other.avg_loot&&avg_level==other.avg_level
                        && avg_Height==other.avg_Height && avg_Hazard==other.avg_Hazard;
                }
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(type,avg_loot,avg_level,avg_Height,avg_Hazard);
            }

        }
        //FOR THE MISSION METHOD
        public class Tool2 
        {
            public string Name { get; set; }
            public string Type { get; set; }

            public int Id { get; set; }

            public override bool Equals(object obj)
            {
                Tool2 other = obj as Tool2;
                if (other==null)
                {
                    return false;
                }
                else
                {
                    return Name == other.Name && Type == other.Type && Id == other.Id;
                }
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(Name,Type,Id);
            }
        }
        // it's for the avg in work method
        public class Tool3
        {
            public string Name { get; set; }
            public double Income { get; set; }
            public double Height { get; set; }
            public double Hazard { get; set; }

            public override bool Equals(object obj)
            {
                Tool3 other = obj as Tool3;
                if (other == null)
                {
                    return false;
                }
                else
                {
                    return Name == other.Name && Income == other.Income && Height == other.Height
                        && Hazard==other.Hazard;
                }
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(Name,Income,Height,Hazard);
            }
        }
        public class Tool4 
        {

            public override int GetHashCode()
            {
                return HashCode.Combine(Name, Type, Id);
            }
        }
        public class Tool5 
        {
            public override int GetHashCode()
            {
                return HashCode.Combine(Name, Type, Id);
            }
        }




    }
}

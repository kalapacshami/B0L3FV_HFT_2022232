using B0L3FV_HFT_2022232.Models;
using B0L3FV_HFT_2022232.Repository;
using System;
using System.Linq;

namespace B0L3FV_HFT_2022232.Logic
{
    internal class MissionLogic
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
    }
}

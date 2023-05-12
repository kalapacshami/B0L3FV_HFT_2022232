using System;
using System.Linq;
using B0L3FV_HFT_2022232.Models;
using B0L3FV_HFT_2022232.Repository;

namespace B0L3FV_HFT_2022232.Logic
{
    public class GoblinLogic : IGoblinLogic
    {
        IRepository<Goblin> repo;

        public GoblinLogic(IRepository<Goblin> repo)
        {
            this.repo = repo;
        }

        public void Create(Goblin item)
        {
            if (item.GoblinName.Count() <4 )
            {
                throw new ArgumentException("The name is too short");
            }
            repo.Create(item);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Goblin Read(int id)
        {
            return repo.Read(id);
        }

        public IQueryable<Goblin> ReadAll()
        {
            return repo.ReadAll();            
            
        }
        

        public void Update(Goblin item)
        {
            repo.Update(item);
        }
    }
}

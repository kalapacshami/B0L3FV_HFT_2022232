using B0L3FV_HFT_2022232.Models;
using B0L3FV_HFT_2022232.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B0L3FV_HFT_2022232.Logic
{
    public class WorkLogic 
    {
        IRepository<Work> repo;

        public WorkLogic(IRepository<Work> repo)
        {
            this.repo = repo;  
        }
        public void Create(Work item)
        {
            if (item.WName.Count() < 4)
            {
                throw new ArgumentException("The name of the work is too short");
            }
            repo.Create(item);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Work Read(int id)
        {
            return repo.Read(id);
        }

        public IQueryable<Work> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Work item)
        {
            repo.Update(item);
        }
    }
}

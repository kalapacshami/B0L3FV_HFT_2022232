using B0L3FV_HFT_2022232.Models;
using B0L3FV_HFT_2022232.Repository;
using static B0L3FV_HFT_2022232.Logic.WorkLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B0L3FV_HFT_2022232.Logic
{
    public interface IWorkLogic
    {
        void Create(Work item);
        void Delete(int id);
        
        Work Read(int id);
        IQueryable<Work> ReadAll();
        void Update(Work item);
    }
}

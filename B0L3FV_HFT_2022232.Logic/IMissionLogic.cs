using B0L3FV_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B0L3FV_HFT_2022232.Logic
{
    public interface IMissionLogic
    {
        void Create(Mission item);
        void Delete(int id);

        Mission Read(int id);
        IQueryable<Mission> GetAll();
        void Update(Mission item);
        
    }
}

using B0L3FV_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B0L3FV_HFT_2022232.Logic
{
    public interface IGoblinLogic
    {
        void Create(Goblin item);
        void Delete (int id);
        Goblin Read(int id);
        IQueryable<Goblin> ReadAll();
        void Update(Goblin item);
    }
}

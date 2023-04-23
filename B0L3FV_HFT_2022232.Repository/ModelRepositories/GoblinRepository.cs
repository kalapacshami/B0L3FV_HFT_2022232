using B0L3FV_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B0L3FV_HFT_2022232.Repository
{
    public class GoblinRepository : Repository<Goblin>, IRepository<Goblin>
    {
        public GoblinRepository(GoblinDbContext ctx) : base(ctx)
        {
        }

        public override Goblin Read(int id)
        {
            return ctx.Goblins.FirstOrDefault(t => t.GoblinID == id);
        }

        public override void Update(Goblin item)
        {
            throw new NotImplementedException();
        }
    }
}

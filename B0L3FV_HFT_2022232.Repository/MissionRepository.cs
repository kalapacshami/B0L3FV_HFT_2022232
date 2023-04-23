using B0L3FV_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B0L3FV_HFT_2022232.Repository
{
    public class MissionRepository : Repository<Mission>, IRepository<Mission>
    {
        public MissionRepository(GoblinDbContext ctx) : base(ctx)
        {
        }

        public override Mission Read(int id)
        {
            return ctx.Missions.FirstOrDefault(t => t.MissionID == id);
        }

        public override void Update(Mission item)
        {
            var old = Read(item.MissionID);
            foreach (var property in old.GetType().GetProperties())
            {
                if (property.GetAccessors().FirstOrDefault(t=>t.IsVirtual)==null)
                {
                    property.SetValue(old, property.GetValue(item));
                }
            }
            ctx.SaveChanges(); 
        }
    }
}

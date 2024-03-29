﻿using B0L3FV_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B0L3FV_HFT_2022232.Repository
{
    public class WorkRepository : Repository<Work>, IRepository<Work>
    {
        public WorkRepository(GoblinDbContext ctx) : base(ctx)
        {
        }

        public override Work Read(int id)
        {
            return ctx.Works.FirstOrDefault(t => t.WID == id);
        }

        public override void Update(Work item)
        {
            var old = Read(item.WID);
            foreach (var property in old.GetType().GetProperties())
            {
                if (property.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    property.SetValue(old, property.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}

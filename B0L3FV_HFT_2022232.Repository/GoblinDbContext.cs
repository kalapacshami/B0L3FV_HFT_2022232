using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Data;
using B0L3FV_HFT_2022232.Models;

namespace B0L3FV_HFT_2022232.Repository
{
    public class GoblinDbContext : DbContext
    {
        public DbSet<Goblin> Goblins { get; set; }

        public DbSet<Work> Works { get; set; }

        public DbSet<Mission> Missions { get; set; }
    }
}

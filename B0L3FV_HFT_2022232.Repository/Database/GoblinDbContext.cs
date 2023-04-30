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

        public GoblinDbContext()
        {
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder Builder)
        {
            if (!Builder.IsConfigured)
            {
                
                Builder.UseLazyLoadingProxies().UseInMemoryDatabase("goblin");
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Goblin>(goblin => goblin
            .HasOne(goblin => goblin.Work)
            .WithMany(work => work.Goblins)
            .HasForeignKey(goblin => goblin.WID));


            modelBuilder.Entity<Mission>(mission => mission
            .HasOne(mission => mission.Goblin)
            .WithMany(goblin => goblin.Missions)
            .HasForeignKey(mission => mission.GoblinID));



            modelBuilder.Entity<Work>().HasData(new Work[]
            {
                new Work("1*Prospector*1*1000*2500*3"),
                new Work("2*Miner*2*1500*2500*4"),
                new Work("3*Blacksmith*3*3000*4500*1"),
                new Work("4*Mechanic*4*1000*1550*2"),
                new Work("5*Engineer*5*3200*4000*1"),
                new Work("6*Cartographer*6*1000*1340*0"),
                new Work("7*Security*7*3200*5500*4")

           });

            //GoblinID = int.Parse(split[0]);
            //WID = int.Parse(split[1]);
            //GoblinName = split[2];
            //Level = int.Parse(split[3]);
            //Money = int.Parse(split[4]);
            //Height = float.Parse(split[5]);
            modelBuilder.Entity<Goblin>().HasData(new Goblin[]
            {

                new Goblin("1*2*Grubsnarl*7*3000*112"),
                new Goblin("2*3*Snikchop*14*1000*179"),
                new Goblin("3*4*Gobblenose*3*1230*145"),
                new Goblin("4*4*Fanggrim*11*2170*154"),
                new Goblin("5*6*Snargletooth*19*3000*131"),
                new Goblin("6*7*Grobblenot*2*5000*148"),
                new Goblin("7*2*Skreechbelly*17*4560*162"),
                new Goblin("8*1*Nibletwist*0*3720*102"),
                new Goblin("9*3*Gruumshank*8*7620*167"),
                new Goblin("10*7*Snotgob*5*1450*123"),
                new Goblin("11*6*Grimgash*16*4320*134"),
                new Goblin("12*4*Droolmaw*1*3420*168"),
                new Goblin("13*2*Stinkwort*12*2160*155"),
                new Goblin("14*1*Wartnose*9*2890*183"),
                new Goblin("15*2*Scragfist*6*4380*159"),
                new Goblin("16*6*Sludgebelch*15*5420*138"),
                new Goblin("17*5*Tanglefoot*4*1260*122"),
                new Goblin("18*4*Pustulegrim*10*4860*171"),
                new Goblin("19*4*Scuttleclaw*18*4550*177"),
                new Goblin("20*3*Snickerfang*13*1590*118"),
                new Goblin("21*3*Gristlepaw*20*1230*184"),
                new Goblin("22*2*Wretchbelly*6*4570*186"),
                new Goblin("23*6*Squicktooth*2*7500*170"),
                new Goblin("24*4*Rattleclank*16*3230*136"),
                new Goblin("25*6*Krambrek*20*61000*42"),
                new Goblin("26*1*Barryl*24*40000*11"),
                new Goblin("27*2*Brumgran*15*32000*6"),
                new Goblin("28*5*Hurtharn*25*44000*60"),
                new Goblin("29*4*Gralmor*25*60000*46"),
                new Goblin("30*7*Grilduhr*25*56000*37")


            });

            //MissionID = int.Parse(split[0]);
            //Date = DateTime.Parse(split[1]);
            //GoblinID = int.Parse(split[2]);
            //Hazard = int.Parse(split[3]);
            //MissionCompleted = bool.Parse(split[4]);
            //MissionDuration = int.Parse(split[5]);
            //MType = split[6];
            //Location = split[7];
            //Kills = int.Parse(split[8]);
            //Deaths = int.Parse(split[9]);
            //Loot = int.Parse(split[10]);

            modelBuilder.Entity<Mission>().HasData(new Mission[]
            {
                new Mission("1*2023.02.21 8:10*1*4*true*21*Mining*The Forest of Whispers*122*1*47000"),
                new Mission("2*2023.02.28 9:18*2*5*false*40*Hunt*The Crystal Spire*320*5*62000"),
                new Mission("3*2023.02.1 10:30*3*1*true*22*Refining*The Sunken City*80*0*45000"),
                new Mission("4*2023.02.3 11:25*4*3*true*15*Salvage Operation*The Caverns of Darkness*95*4*40000"),
                new Mission("5*2023.02.9 12:45*5*2*true*14*Extraction*The Cloud Fortress*156*1*78000"),
                new Mission("6*2023.03.2 12:22*6*4*true*25*Escort*The Dragon's Lair*192*0*81000"),
                new Mission("7*2023.03.21 13:02*22*4*false*28*Fighting*The Shadow Realm*172*1*45000"),
                new Mission("8*2023.01.21 8:00*8*2*true*29*Sabotage*The Enchanted Garden*254*0*33000"),
                new Mission("9*2023.01.2 9:24*9*3*true*31*Mining*The Shadow Realm*320*3*26000"),
                new Mission("10*2023.04.12 16:14*10*4*true*21*Fighting*The Crystal Caves*46*1*82000"),
                new Mission("11*2023.03.11 15:56*11*5*true*14*Mining*The Celestial Observatory*53*2*54000"),
                new Mission("12*2023.04.9 19:32*21*4*false*35*Extraction*The Sunken City*122*2*39000"),
                new Mission("13*2023.02.14 20:26*13*4*true*12*Salvage Operation*The Shadow Realm*153*0*41000"),
                new Mission("14*2023.01.24 4:29*14*1*true*34*Mining*The Crystal Spire*146*0*92000"),
                new Mission("15*2023.01.19 5:13*15*3*true*43*Salvage Operation*The Sunken City*175*0*46000"),
                new Mission("16*2023.03.18 7:52*16*2*false*12*Mining*The Cloud Fortress*462*1*24000"),
                new Mission("17*2023.03.5 9:17*17*4*true*26*Hunt*The Forest of Whispers*246*0*65000"),
                new Mission("18*2023.04.5 20:38*18*4*true*21*Mining*The Sunken City*283*0*71000"),
                new Mission("19*2023.01.30 10:19*19*5*true*15*Refining*The Forest of Whispers*72*3*85000"),
                new Mission("20*2023.03.14 12:00*21*2*false*27*Mining*The Crystal Caves*166*2*17000"),
                new Mission("21*2023.03.2 7:52*22*4*false*42*Mining*The Enchanted Garden*157*3*38000"),
                new Mission("22*2023.02.17 9:17*24*3*true*24*Fighting*The Sunken City*132*6*24000"),
                new Mission("23*2023.02.5 20:38*26*2*true*25*Mining*The Dragon's Lair*112*0*45000"),
                new Mission("24*2023.03.30 10:19*19*4*true*18*Mining*The Celestial Observatory*106*0*37000"),
                new Mission("25*2023.02.14 12:00*21*4*false*29*Extraction*The Crystal Spire*108*1*75000"),
                new Mission("26*2023.04.18 7:52*11*5*false*12*Mining*The Enchanted Garden*157*2*32000"),


            });
        }
    }
}

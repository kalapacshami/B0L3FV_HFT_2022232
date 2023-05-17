﻿using B0L3FV_HFT_2022232.Logic;
using B0L3FV_HFT_2022232.Models;
using B0L3FV_HFT_2022232.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using static B0L3FV_HFT_2022232.Logic.MissionLogic;

namespace B0L3FV_HFT_2022232.Test
{
    [TestFixture]
    public class TesterClass
    {
        MissionLogic logic;
        Mock<IRepository<Mission>> mockmission;
        [SetUp]
        public void Init() 
        {

            Mission miss1 = new Mission("1*2023.02.21 8:10*1*4*true*21*Mining*The Forest of Whispers*122*1*47000");
            Mission miss2 = new Mission("2*2023.02.28 9:18*2*5*false*40*Hunt*The Crystal Spire*320*5*62000");

            Goblin goblin1 = new Goblin("1*2*Grubsnarl*7*3000*112");
            Goblin goblin2 = new Goblin("2*3*Snikchop*14*1000*179");

            Work work1= new Work("1*Prospector*1*1000*2500*3");
            Work work2= new Work("2*Miner*2*1500*2500*4");
            ICollection<Mission> testmissio = new Collection<Mission>();
            testmissio.Add(miss1);
            testmissio.Add(miss2);
            goblin1.Missions=testmissio;
            goblin2.Missions=testmissio;
            ICollection<Goblin> testgoblin = new Collection<Goblin>();
            testgoblin.Add(goblin1);
            testgoblin.Add(goblin2);
            work1.Goblins=testgoblin;
            work2.Goblins = testgoblin;
            goblin1.Work = work1;
            goblin2.Work = work2;
            List<Work> workes = new List<Work>();
            workes.Add(work1);
            workes.Add(work2);
            mockmission=new Mock<IRepository<Mission>>();

            mockmission.Setup(t => t.ReadAll()).Returns(testmissio.AsQueryable());
            logic=new MissionLogic(mockmission.Object);




        }
        //Mission miss1 = new Mission("1*2023.02.21 8:10*1*4*true*21*Mining*The Forest of Whispers*122*1*47000");
        //Mission miss2 = new Mission("2*2023.02.28 9:18*2*5*false*40*Hunt*The Crystal Spire*320*5*62000");

        //Goblin goblin1 = new Goblin("1*2*Grubsnarl*7*3000*112");
        //Goblin goblin2 = new Goblin("2*3*Snikchop*14*1000*179");

        //Work work1 = new Work("1*Prospector*1*1000*2500*3");
        //Work work2 = new Work("2*Miner*2*1500*2500*4");

        [Test]
        public void AVGMissiontest() 
        {
            var actual = logic.AVGMission().ToList();
            var expected = new List<Tool1>()
            {
                new Tool1()
                {
                    type="Mining",
                    avg_Hazard=4,
                    avg_loot=47000,
                    avg_level=7,
                    avg_Height=112,
                },
                new Tool1()
                {
                    type="Hunt",
                    avg_Hazard=5,
                    avg_loot=62000,
                    avg_level=14,
                    avg_Height=179,
                }
            };
            
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Missionstest() 
        {
            var actual = logic.Missions().ToList();
            var expected = new List<Tool2>()
            {
                new Tool2()
                {
                Name="Prospector",
                Id=1,
                Type="Mining"
                },
                new Tool2()
                {
                Name="Miner",
                Id=2,
                Type="Hunt"
                },
            };

            Assert.AreEqual(actual, expected);
        }
        [Test]
        public void AVGWorktest() 
        {
            var actual = logic.AVGWork().ToList();
            var expected = new List<Tool3>()
            {
                new Tool3()
                {
                    Name = "Prospector",
                    Height = 40,
                    Hazard = 4,
                    Income = 39000,
                },
                new Tool3()
                {
                    Name = "Miner",
                    Height = 30,
                    Hazard = 5,
                    Income = 29000,
                }
            };
            ;
            Assert.AreEqual(actual, expected);

        }

        //Mission miss1 = new Mission("1*2023.02.21 8:10*1*4*true*21*Mining*The Forest of Whispers*122*1*47000");
        //Mission miss2 = new Mission("2*2023.02.28 9:18*2*5*false*40*Hunt*The Crystal Spire*320*5*62000");

        //Goblin goblin1 = new Goblin("1*2*Grubsnarl*7*3000*112");
        //Goblin goblin2 = new Goblin("2*3*Snikchop*14*1000*179");

        //Work work1 = new Work("1*Prospector*1*1000*2500*3");
        //Work work2 = new Work("2*Miner*2*1500*2500*4");
        [Test]
        public void AVGGoblintest() 
        {
            var actual = logic.AVGGoblin().ToList();
            var expected = new List<Tool4>()
            {
                new Tool4()
                {
                    Name = "Grubsnarl",
                    Loot = 47000,
                    Kill = 122,
                    Death= 1,
                     Duration= 21
                },

                new Tool4()
                {
                    Name = "Snikchop",
                    Loot = 62000,
                    Kill = 320,
                    Death= 5,
                    Duration = 40
                }


            };
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void KillCountMissionstest()
        {
            var actual = logic.KillCountMissions().ToList();
            var expected = new List<Tool5>()
            {
                new Tool5()
                {
                    Goblin_work = "Prospector",
                    Name = "Grubsnarl",
                    Kill = 320,
                    Id = 2,
                    Type = "Hunt",
                }
            };


            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void CreateMissionTestCorrectTypeWithCorrectLocation()
        {
            var mission = new Mission() { MType = "test", Location = "test" };

            logic.Create(mission);

            mockmission.Verify(r => r.Create(mission), Times.Once);

        }
        [Test]
        public void CreateMissonTestInCorrectTypeWithCorrectLocation()
        {
            var mission = new Mission() { MType = "te", Location = "test" };
            try
            {
                logic.Create(mission);
            }
            catch
            {

            }
            mockmission.Verify(r => r.Create(mission), Times.Never);
        }
        [Test]
        public void CreateMissionTestCorrectTypeWithInCorrectLocation()
        {
            var mission = new Mission() { MType = "test", Location = "te" };
            try
            {
                logic.Create(mission);
            }
            catch
            {

            }
            mockmission.Verify(r => r.Create(mission), Times.Never);

        }
        [Test]
        public void CreateMissionTestCorrectTypeWithInCorrectLocation2()
        {
            var mission = new Mission() { MType = "test", Location = "XDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDXDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDddXDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDddXDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDddDdd" };
            try
            {
                logic.Create(mission);
            }
            catch
            {

            }
            mockmission.Verify(r => r.Create(mission), Times.Never);

        }
        [Test]
        public void DelelteTest()
        {
            logic.Delete(1);

            mockmission.Verify(r => r.Delete(1), Times.Once);

        }


    }
}

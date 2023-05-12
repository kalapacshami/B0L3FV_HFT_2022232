using B0L3FV_HFT_2022232.Models;

using System;
using System.Linq;

using ConsoleTools;
using System.Collections.Generic;

namespace B0L3FV_HFT_2022232.Client
{
    internal class Program
    {
        //static GoblinLogic goblinlog;
        //static WorkLogic worklog;
        //static MissionLogic missionlog;


        static void Create(string ent) 
        {
            Console.WriteLine(ent+" create");
            Console.ReadLine();

        }
        static void Update(string ent) 
        {
            Console.WriteLine(ent + " update");
            Console.ReadLine();
        }
        static void List(string ent)
        {
            //if (ent == "Goblin")
            //{
            //    var items = goblinlog.ReadAll();
            //    Console.WriteLine("Id" + "\t" + "Name");
            //    foreach (var item in items)
            //    {
            //        Console.WriteLine(item.GoblinID + "\t" + item.GoblinName);
            //    }
            //}
            //Console.ReadLine();
        }



        static void Delete(string ent) 
        {
            Console.WriteLine(ent + " delete");
            Console.ReadLine();
        }





        static void Main(string[] args)
        {

            //var ctx = new GoblinDbContext();
            ////var goblins = ctx.Goblins.ToArray();

            
            //var Gobrepo = new GoblinRepository(ctx);
            //var Misrepo = new MissionRepository(ctx);
            //var Workrepo = new WorkRepository(ctx);

            





            var goblinsubmenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Goblin"))
                .Add("Create", () => Create("Goblin"))
                .Add("Delete", () => Delete("Goblin"))
                .Add("Update", () => Update("Goblin"))
                .Add("Exit", ConsoleMenu.Close);

            var Worksubmenu = new ConsoleMenu(args, level: 1)
               .Add("List", () => List("Work"))
               .Add("Create", () => Create("Work"))
               .Add("Delete", () => Delete("Work"))
               .Add("Update", () => Update("Work"))
               .Add("Exit", ConsoleMenu.Close);

            var Missionsubmenu = new ConsoleMenu(args, level: 1)
               .Add("List", () => List("Mission"))
               .Add("Create", () => Create("Mission"))
               .Add("Delete", () => Delete("Mission"))
               .Add("Update", () => Update("Mission"))
               .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Goblins", () => goblinsubmenu.Show())
                .Add("Works", () => Worksubmenu.Show())
                .Add("Missions", () => Missionsubmenu.Show())

                .Add("Exit", ConsoleMenu.Close);

            menu.Show();


        }

        


        static void Missions() 
        {
        
        }

        static void AVGWork() 
        {
        
        }

        static void AVGGoblin() 
        {
        
        }

        static void KillCountMissions() 
        {
        
        }

        public class Tool1
        {
            public string type { get; set; }
            public double avg_loot { get; set; }
            public double avg_level { get; set; }
            public double avg_Height { get; set; }
            public double avg_Hazard { get; set; }

            public override bool Equals(object obj)
            {
                Tool1 other = obj as Tool1;
                if (other == null)
                {
                    return false;
                }
                else
                {
                    return type == other.type && avg_loot == other.avg_loot && avg_level == other.avg_level
                        && avg_Height == other.avg_Height && avg_Hazard == other.avg_Hazard;
                }
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(type, avg_loot, avg_level, avg_Height, avg_Hazard);
            }

        }







        //FOR THE MISSION METHOD
        public class Tool2
        {
            public string Name { get; set; }
            public string Type { get; set; }

            public int Id { get; set; }

            public override bool Equals(object obj)
            {
                Tool2 other = obj as Tool2;
                if (other == null)
                {
                    return false;
                }
                else
                {
                    return Name == other.Name && Type == other.Type && Id == other.Id;
                }
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(Name, Type, Id);
            }
        }







        // it's for the avg in work method
        public class Tool3
        {
            public string Name { get; set; }
            public double Income { get; set; }
            public double Height { get; set; }
            public double Hazard { get; set; }

            public override bool Equals(object obj)
            {
                Tool3 other = obj as Tool3;
                if (other == null)
                {
                    return false;
                }
                else
                {
                    return Name == other.Name && Income == other.Income && Height == other.Height
                        && Hazard == other.Hazard;
                }
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(Name, Income, Height, Hazard);
            }
        }









        // for the goblin non-crud method
        public class Tool4
        {
            public string Name { get; set; }
            public double Loot { get; set; }
            public double Kill { get; set; }
            public double Death { get; set; }
            public double Duration { get; set; }

            public override bool Equals(object obj)
            {
                Tool4 other = obj as Tool4;
                if (other == null)
                {
                    return false;
                }
                else
                {
                    return Name == other.Name && Loot == other.Loot && Kill == other.Kill
                        && Death == other.Death
                        && Duration == other.Duration;
                }
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(Name, Loot, Kill, Death, Duration);
            }
        }







        // For the killin type of method

        public class Tool5
        {
            public int Id { get; set; }
            public string Type { get; set; }
            public string Name { get; set; }
            public int Kill { get; set; }
            public string Goblin_work { get; set; }

            public override bool Equals(object obj)
            {
                Tool5 other = obj as Tool5;
                if (other == null)
                {
                    return false;
                }
                else
                {
                    return Name == other.Name && Type == other.Type &&
                        Id == other.Id && Kill == other.Kill && Goblin_work == other.Goblin_work;
                }
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(Id, Type, Name, Kill, Goblin_work);
            }
        }
    }
}

using B0L3FV_HFT_2022232.Models;

using System;
using System.Linq;

using ConsoleTools;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace B0L3FV_HFT_2022232.Client
{
    internal class Program
    {

        static RestService rest;

        static void Create(string ent) 
        {
            try
            {
                if (ent == "Goblin")
                {
                    Console.WriteLine("Enter goblin's name: ");
                    string name = Console.ReadLine();
                    rest.Post(new Goblin()
                    {
                        GoblinName = name
                    }, "Goblin");
                }
                else if (ent == "Work") 
                {
                    Console.WriteLine("What should we call this work: ");
                    string name = Console.ReadLine();
                    rest.Post(new Work()
                    {
                        WName = name
                    }, "Work");
                }
                else if (ent == "Mission")
                {
                    Console.WriteLine("What type of Mission is this: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Where is this Mission takes place (location): ");
                    string name2 = Console.ReadLine();
                    rest.Post(new Mission()
                    {
                        MType = name,
                        Location = name2
                    },"Mission") ;

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }


        static void Update(string ent) 
        {
            try
            {
                if (ent == "Goblin")
                {
                    Console.Write("Give me the ID of the goblin, you want to update: ");
                    int id = int.Parse(Console.ReadLine());
                    Goblin gob = rest.Get<Goblin>(id, "Goblin");
                    Console.Write($"new name, old name: {gob.GoblinName}");
                    string name = Console.ReadLine();
                    gob.GoblinName = name;
                    rest.Put(gob, "Goblin");
                }
                else if (ent == "Work") 
                {
                    Console.Write("Give me the ID of the work, you want to update: ");
                    int id = int.Parse(Console.ReadLine());
                    Work gob = rest.Get<Work>(id, "Work");
                    Console.Write($"new name, old name: {gob.WName}");
                    string name = Console.ReadLine();
                    gob.WName = name;
                    rest.Put(gob, "Work");
                }
                else if (ent == "Mission")
                {
                    Console.Write("Give me the ID of the Mission, you want to update: ");
                    int id = int.Parse(Console.ReadLine());
                    Mission gob = rest.Get<Mission>(id, "Work");
                    Console.Write($"new type, old type: {gob.MType}");
                    string name = Console.ReadLine();
                    Console.Write($"new location, old location: {gob.MType}");
                    string name2 = Console.ReadLine();
                    gob.MType = name;
                    gob.Location = name2;
                    rest.Put(gob, "Mission");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

       
        static void List(string ent)
        {
            try
            {
                if (ent == "Goblin")
                {
                    List<Goblin> goblin = rest.Get<Goblin>("Goblin");
                    foreach (var item in goblin)
                    {
                        Console.WriteLine(item.GoblinID + " Name:" + item.GoblinName + " WorkID"+item.WID+" Level:"+item.Level + " Money:" + item.Money + " Height:" + item.Height);
                    }

                }
                else if (ent == "Work") 
                {
                    List<Work> work = rest.Get<Work>("Work");
                    foreach (var item in work)
                    {
                        Console.WriteLine(item.WID + " Type:" + item.WName + " HazardLevel:" + item.HazardLevel + " MinSalary:" + item.Min_Money + " MaxSalary:" + item.Max_Money);
                    }
                }
                else if (ent == "Mission")
                {
                    List<Mission> mission = rest.Get<Mission>("Mission");
                    foreach (var item in mission)
                    {
                        Console.WriteLine(item.MissionID + " MissionType:" + item.MType+" Location:"+item.Location + " Goblin:" + item.Goblin + " Deaths:" + item.Deaths + " Kills:" + item.Kills + " Date:" + item.Date);
                    }
                }
                Console.ReadLine();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }



        static void Delete(string ent) 
        {
            try
            {
                if (ent == "Goblin")
                {
                    Console.Write("Which Id goblin you want to delete: ");
                    int id = int.Parse(Console.ReadLine());
                    rest.Delete(id, "Goblin");
                }
                else if (ent == "Work")
                {
                    Console.Write("Which Id work you want to delete: ");
                    int id = int.Parse(Console.ReadLine());
                    rest.Delete(id, "Work");
                }
                else if (ent == "Mission") 
                {
                    Console.Write("Which Id mission you want to delete: ");
                    int id = int.Parse(Console.ReadLine());
                    rest.Delete(id, "Mission");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }





        static void Main(string[] args)
        {

            rest = new RestService("http://localhost:11828/api/", "Goblin");



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

            var ToolSubMenu = new ConsoleMenu(args, level: 1)
                .Add("AVGMission", AVGMission)
                .Add("Missions", Missions)
                .Add("AVGWork", AVGWork)
                .Add("AVGGoblin", AVGGoblin)
                .Add("KillCountMissions", KillCountMissions)
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Goblins", () => goblinsubmenu.Show())
                .Add("Works", () => Worksubmenu.Show())
                .Add("Missions", () => Missionsubmenu.Show())
                .Add("Non-Crud",()=>ToolSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();


        }


        static void AVGMission() 
        {
            try
            {
                IEnumerable<Tool1> result = rest.Get<Tool1>("/api/Tool/AVGMission");

                foreach (var item in result)
                {
                    Console.WriteLine(item.type + ":AvgHazzard " + item.avg_Hazard + ":AvgBeardLength " + item.avg_Height + ":AvgLoot" + item.avg_loot + ":AvgLvl " + item.avg_level);
                }
                Console.ReadLine();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        static void Missions() 
        {

            try
            {
                IEnumerable<Tool2> result = rest.Get<Tool2>("/api/Tool/Missions");

                foreach (var item in result)
                {
                    Console.WriteLine(item.Id + ": " + item.Type + ": " + item.Name);
                }
                Console.ReadLine();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void AVGWork() 
        {

            try
            {
                IEnumerable<Tool3> result = rest.Get<Tool3>("/api/Tool/AVGWork");

                foreach (var item in result)
                {
                    Console.WriteLine(item.Name + ":AvgIncome " + item.Income + ":AvgBeardLength " + item.Height + ":AvgHazzard " + item.Hazard);
                }
                Console.ReadLine();

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        static void AVGGoblin() 
        {

            try
            {
                IEnumerable<Tool4> result = rest.Get<Tool4>("/api/Tool/AVGGoblin");

                foreach (var item in result)
                {
                    Console.WriteLine(item.Name + ":AvgMissionLength " + item.Duration + ":AvgKills " + item.Kill + ":AvgDowns " + item.Death + ":AvgLoot " + item.Loot);
                }
                Console.ReadLine();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        static void KillCountMissions() 
        {

            try
            {
                IEnumerable<Tool5> result = rest.Get<Tool5>("/api/Tool/KillCountMissions");

                foreach (var item in result)
                {
                    Console.WriteLine(item.Id + ": " + item.Type + ": " + item.Name + ": " + item.Goblin_work + ":Kills " + item.Kill);
                }
                Console.ReadLine();

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
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

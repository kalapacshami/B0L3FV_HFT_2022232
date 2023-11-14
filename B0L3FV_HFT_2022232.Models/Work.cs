using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace B0L3FV_HFT_2022232.Models
{
    public class Work
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WID { get; set; }
        [StringLength(100)]
        public string WName { get; set; }
        public int Min_Money { get; set; }
        public int Max_Money { get; set; }
        [Range(0, 5)]
        public int HazardLevel { get; set; }
        public int LocID { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Goblin> Goblins { get; set; }
        public Work()
        {

        }
        public Work(string line)
        {
            string[] split = line.Split('*');

            WID = int.Parse(split[0]);
            WName = split[1];
            LocID = int.Parse(split[2]);
            Min_Money = int.Parse(split[3]);
            Max_Money = int.Parse(split[4]);
            HazardLevel = int.Parse(split[5]);

        }
    }
    // for the avg mission non-crud method
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

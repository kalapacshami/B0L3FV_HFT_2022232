using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace B0L3FV_HFT_2022232.Models
{
    public class Goblin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GoblinID { get; set; }

        public int WID { get; set; }
        [StringLength(140)]
        public string GoblinName { get; set; }
        [Range(0, 20)]
        public int Level { get; set; }
        public int Money { get; set; }
        public float Height { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Mission> Missions { get; set; }
        [NotMapped]
        public virtual Work Work { get; set; }
        public Goblin()
        {

        }
        public Goblin(string line)
        {
            string[] split = line.Split('*');

            GoblinID = int.Parse(split[0]);
            WID = int.Parse(split[1]);
            GoblinName = split[2];
            Level = int.Parse(split[3]);
            Money = int.Parse(split[4]);
            Height = float.Parse(split[5]);
        }
    }
}

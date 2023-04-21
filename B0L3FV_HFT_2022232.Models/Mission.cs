using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B0L3FV_HFT_2022232.Models
{
    public class Mission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MissionID { get; set; }
        public DateTime Date { get; set; }
        [Range(0, 5)]
        public int Hazard { get; set; }
        public int GoblinID { get; set; }
        public bool MissionCompleted { get; set; }
        public int MissionDuration { get; set; }
        [StringLength(100)]
        public string MType { get; set; }
        [StringLength(100)]
        public string Location { get; set; }
        public int Kills { get; set; }
        public int Loot { get; set; }
        public int Deaths { get; set; }

        public virtual Goblin Goblin { get; set; }
        public Mission()
        {

        }
        public Mission(string line)
        {
            string[] split = line.Split('*');
            MissionID = int.Parse(split[0]);
            Date = DateTime.Parse(split[1]);
            GoblinID = int.Parse(split[2]);
            Hazard = int.Parse(split[3]);
            MissionCompleted = bool.Parse(split[4]);
            MissionDuration = int.Parse(split[5]);
            MType = split[6];
            Location = split[7];
            Kills = int.Parse(split[8]);
            Deaths = int.Parse(split[9]);
            Loot = int.Parse(split[10]);
        }
    }
}

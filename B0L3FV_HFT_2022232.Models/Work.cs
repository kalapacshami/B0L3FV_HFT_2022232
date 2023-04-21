using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}

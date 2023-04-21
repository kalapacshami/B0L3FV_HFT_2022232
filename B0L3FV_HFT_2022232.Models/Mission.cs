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
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace B0L3FV_HFT_2022232.Models
{
    public class Goblin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GoblinID { get; set; }
    }
}

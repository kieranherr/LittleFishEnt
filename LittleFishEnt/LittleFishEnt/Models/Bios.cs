using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LittleFishEnt.Models
{
    public class Bios
    {
        [Key]
        public int BioId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Type { get; set; }

    }
}

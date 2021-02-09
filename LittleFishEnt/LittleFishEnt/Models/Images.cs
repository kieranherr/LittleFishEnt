using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LittleFishEnt.Models
{
    public class Images
    {
       [Key]
        public int ImageId { get; set; }
        public string ImageName { get; set; }
        public string ImageLocation { get; set; }
        
    }

}

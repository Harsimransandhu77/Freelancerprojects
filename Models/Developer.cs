using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancerprojects.Models
{
    public class Developer
    {
        //id 
        public int Id { get; set; }

        //Developer name 
        [Required]
        public string Name { get; set; }

       // experience
        public int Experience { get; set; }
    }
}

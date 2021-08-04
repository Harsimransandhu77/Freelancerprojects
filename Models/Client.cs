using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancerprojects.Models
{
    public class Client
    {
       //  id
        public int Id { get; set; }

        // name
        [Required]
        public string Name { get; set; }

        // email
        public string Email { get; set; }

       
        public Boolean Experience { get; set; }
    }
}

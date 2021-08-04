using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancerprojects.Models
{
    public class Project
    {
        //t id 
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }


        //Details 
        public string Details { get; set; }

        //Price
        public decimal Price { get; set; }

        //Client 
        public int ClientId { get; set; }

        //Client 
        public Client Client { get; set; }
    }
}

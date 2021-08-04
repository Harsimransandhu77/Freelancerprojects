using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancerprojects.Models
{
    public class Bid
    {

        // id 
        public int Id { get; set; }

        //value 
        public decimal Value { get; set; }


        // Project id related key

        public int ProjectId { get; set; }

        //Developer related key
        public int DeveloperId { get; set; }

        //Project reference

        public Project Project { get; set; }

        //Developer reference
        public Developer Developer { get; set; }

    }
}

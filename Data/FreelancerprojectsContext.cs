using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Freelancerprojects.Models;

namespace Freelancerprojects.Data
{
    public class FreelancerprojectsContext : DbContext
    {
        public FreelancerprojectsContext (DbContextOptions<FreelancerprojectsContext> options)
            : base(options)
        {
        }

        public DbSet<Freelancerprojects.Models.Developer> Developer { get; set; }

        public DbSet<Freelancerprojects.Models.Client> Client { get; set; }

        public DbSet<Freelancerprojects.Models.Bid> Bid { get; set; }

        public DbSet<Freelancerprojects.Models.Project> Project { get; set; }
    }
}

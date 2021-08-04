using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Freelancerprojects.Data;
using Freelancerprojects.Models;

namespace Freelancerprojects.Pages.Bids
{
    public class IndexModel : PageModel
    {
        private readonly Freelancerprojects.Data.FreelancerprojectsContext _context;

        public IndexModel(Freelancerprojects.Data.FreelancerprojectsContext context)
        {
            _context = context;
        }

        public IList<Bid> Bid { get;set; }

        public async Task OnGetAsync()
        {
            Bid = await _context.Bid
                .Include(b => b.Developer)
                .Include(b => b.Project).ToListAsync();
        }
    }
}

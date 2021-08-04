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
    public class DetailsModel : PageModel
    {
        private readonly Freelancerprojects.Data.FreelancerprojectsContext _context;

        public DetailsModel(Freelancerprojects.Data.FreelancerprojectsContext context)
        {
            _context = context;
        }

        public Bid Bid { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bid = await _context.Bid
                .Include(b => b.Developer)
                .Include(b => b.Project).FirstOrDefaultAsync(m => m.Id == id);

            if (Bid == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

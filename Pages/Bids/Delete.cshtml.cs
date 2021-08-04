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
    public class DeleteModel : PageModel
    {
        private readonly Freelancerprojects.Data.FreelancerprojectsContext _context;

        public DeleteModel(Freelancerprojects.Data.FreelancerprojectsContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bid = await _context.Bid.FindAsync(id);

            if (Bid != null)
            {
                _context.Bid.Remove(Bid);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

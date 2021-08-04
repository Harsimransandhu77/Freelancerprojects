using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Freelancerprojects.Data;
using Freelancerprojects.Models;

namespace Freelancerprojects.Pages.Bids
{
    public class EditModel : PageModel
    {
        private readonly Freelancerprojects.Data.FreelancerprojectsContext _context;

        public EditModel(Freelancerprojects.Data.FreelancerprojectsContext context)
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
           ViewData["DeveloperId"] = new SelectList(_context.Developer, "Id", "Name");
           ViewData["ProjectId"] = new SelectList(_context.Set<Project>(), "Id", "Title");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Bid).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BidExists(Bid.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BidExists(int id)
        {
            return _context.Bid.Any(e => e.Id == id);
        }
    }
}

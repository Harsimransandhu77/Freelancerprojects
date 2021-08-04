using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Freelancerprojects.Data;
using Freelancerprojects.Models;

namespace Freelancerprojects.Pages.Bids
{
    public class CreateModel : PageModel
    {
        private readonly Freelancerprojects.Data.FreelancerprojectsContext _context;

        public CreateModel(Freelancerprojects.Data.FreelancerprojectsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DeveloperId"] = new SelectList(_context.Developer, "Id", "Name");
        ViewData["ProjectId"] = new SelectList(_context.Set<Project>(), "Id", "Title");
            return Page();
        }

        [BindProperty]
        public Bid Bid { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Bid.Add(Bid);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

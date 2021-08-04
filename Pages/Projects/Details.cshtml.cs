﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Freelancerprojects.Data;
using Freelancerprojects.Models;

namespace Freelancerprojects.Pages.Projects
{
    public class DetailsModel : PageModel
    {
        private readonly Freelancerprojects.Data.FreelancerprojectsContext _context;

        public DetailsModel(Freelancerprojects.Data.FreelancerprojectsContext context)
        {
            _context = context;
        }

        public Project Project { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Project = await _context.Project
                .Include(p => p.Client).FirstOrDefaultAsync(m => m.Id == id);

            if (Project == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AvcolStaff.Data;
using AvcolStaff.Models;

namespace AvcolStaff.Pages.RatingS
{
    public class CreateModel : PageModel
    {
        private readonly AvcolStaff.Data.AvcolStaffContext _context;

        public CreateModel(AvcolStaff.Data.AvcolStaffContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["StaffID"] = new SelectList(_context.Staff, "StaffID", "FullName");
            return Page();
        }

        [BindProperty]
        public Rating Rating { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Rating.Add(Rating);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

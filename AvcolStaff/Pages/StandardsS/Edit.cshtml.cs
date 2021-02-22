using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AvcolStaff.Data;
using AvcolStaff.Models;

namespace AvcolStaff.Pages.StandardsS
{
    public class EditModel : PageModel
    {
        private readonly AvcolStaff.Data.AvcolStaffContext _context;

        public EditModel(AvcolStaff.Data.AvcolStaffContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Standards Standards { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Standards = await _context.Standards.FirstOrDefaultAsync(m => m.StandardsID == id);

            if (Standards == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Standards).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StandardsExists(Standards.StandardsID))
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

        private bool StandardsExists(string id)
        {
            return _context.Standards.Any(e => e.StandardsID == id);
        }
    }
}

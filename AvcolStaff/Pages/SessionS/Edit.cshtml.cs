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

namespace AvcolStaff.Pages.SessionS
{
    public class EditModel : PageModel
    {
        private readonly AvcolStaff.Data.AvcolStaffContext _context;

        public EditModel(AvcolStaff.Data.AvcolStaffContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sessions Sessions { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sessions = await _context.Sessions
                .Include(s => s.Staff)
                .Include(s => s.Subjects).FirstOrDefaultAsync(m => m.StaffID == id);

            if (Sessions == null)
            {
                return NotFound();
            }
           ViewData["StaffID"] = new SelectList(_context.Staff, "StaffID", "FirstName");
           ViewData["SubjectsID"] = new SelectList(_context.Subjects, "SubjectsID", "SubjectsID");
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

            _context.Attach(Sessions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SessionsExists(Sessions.StaffID))
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

        private bool SessionsExists(int id)
        {
            return _context.Sessions.Any(e => e.StaffID == id);
        }
    }
}

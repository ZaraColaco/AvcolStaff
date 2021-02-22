using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AvcolStaff.Data;
using AvcolStaff.Models;

namespace AvcolStaff.Pages.StandardsS
{
    public class DeleteModel : PageModel
    {
        private readonly AvcolStaff.Data.AvcolStaffContext _context;

        public DeleteModel(AvcolStaff.Data.AvcolStaffContext context)
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Standards = await _context.Standards.FindAsync(id);

            if (Standards != null)
            {
                _context.Standards.Remove(Standards);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

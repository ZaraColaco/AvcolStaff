using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AvcolStaff.Data;
using AvcolStaff.Models;

namespace AvcolStaff.Pages.SalaryS
{
    public class DeleteModel : PageModel
    {
        private readonly AvcolStaff.Data.AvcolStaffContext _context;

        public DeleteModel(AvcolStaff.Data.AvcolStaffContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Salary Salary { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Salary = await _context.Salary.FirstOrDefaultAsync(m => m.SalaryID == id);

            if (Salary == null)
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

            Salary = await _context.Salary.FindAsync(id);

            if (Salary != null)
            {
                _context.Salary.Remove(Salary);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

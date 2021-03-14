using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AvcolStaff.Data;
using AvcolStaff.Models;

namespace AvcolStaff.Pages.DepartmentStaffS
{
    public class DeleteModel : PageModel
    {
        private readonly AvcolStaff.Data.AvcolStaffContext _context;

        public DeleteModel(AvcolStaff.Data.AvcolStaffContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DepartmentStaff DepartmentStaff { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DepartmentStaff = await _context.DepartmentStaff
                .Include(d => d.Departments)
                .Include(d => d.Staff).FirstOrDefaultAsync(m => m.DepartmentStaffID == id);

            if (DepartmentStaff == null)
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

            DepartmentStaff = await _context.DepartmentStaff.FindAsync(id);

            if (DepartmentStaff != null)
            {
                _context.DepartmentStaff.Remove(DepartmentStaff);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

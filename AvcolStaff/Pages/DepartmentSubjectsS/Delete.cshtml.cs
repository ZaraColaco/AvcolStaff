using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AvcolStaff.Data;
using AvcolStaff.Models;

namespace AvcolStaff.Pages.DepartmentSubjectsS
{
    public class DeleteModel : PageModel
    {
        private readonly AvcolStaff.Data.AvcolStaffContext _context;

        public DeleteModel(AvcolStaff.Data.AvcolStaffContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DepartmentSubjects DepartmentSubjects { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DepartmentSubjects = await _context.DepartmentSubjects
                .Include(d => d.Departments)
                .Include(d => d.Subjects).FirstOrDefaultAsync(m => m.DepartmentSubjectsID == id);

            if (DepartmentSubjects == null)
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

            DepartmentSubjects = await _context.DepartmentSubjects.FindAsync(id);

            if (DepartmentSubjects != null)
            {
                _context.DepartmentSubjects.Remove(DepartmentSubjects);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

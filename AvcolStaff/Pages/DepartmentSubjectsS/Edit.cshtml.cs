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

namespace AvcolStaff.Pages.DepartmentSubjectsS
{
    public class EditModel : PageModel
    {
        private readonly AvcolStaff.Data.AvcolStaffContext _context;

        public EditModel(AvcolStaff.Data.AvcolStaffContext context)
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
           ViewData["DepartmentsID"] = new SelectList(_context.Departments, "DepartmentsID", "DepartmentName");
           ViewData["SubjectsID"] = new SelectList(_context.Subjects, "SubjectsID", "SubjectName");
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
            DepartmentSubjects sub = (from t1 in _context.DepartmentSubjects
                                      where t1.SubjectsID == DepartmentSubjects.SubjectsID
                                      select t1).FirstOrDefault();
            if (sub != null)
            {
                ViewData["DepartmentsID"] = new SelectList(_context.Departments, "DepartmentsID", "DepartmentName");
                ViewData["SubjectsID"] = new SelectList(_context.Subjects, "SubjectsID", "SubjectName");
                ModelState.AddModelError("Custom", "Subject has already been asigned a department");
                return Page();
            }
            else
            {
                _context.DepartmentSubjects.Add(DepartmentSubjects);
                await _context.SaveChangesAsync();
            }

            _context.Attach(DepartmentSubjects).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentSubjectsExists(DepartmentSubjects.DepartmentSubjectsID))
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

        private bool DepartmentSubjectsExists(int id)
        {
            return _context.DepartmentSubjects.Any(e => e.DepartmentSubjectsID == id);
        }
    }
}

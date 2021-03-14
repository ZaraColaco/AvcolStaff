using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AvcolStaff.Data;
using AvcolStaff.Models;

namespace AvcolStaff.Pages.DepartmentSubjectsS
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
        ViewData["DepartmentsID"] = new SelectList(_context.Departments, "DepartmentsID", "DepartmentName");
        ViewData["SubjectsID"] = new SelectList(_context.Subjects, "SubjectsID", "SubjectName");
            return Page();
        }

        [BindProperty]
        public DepartmentSubjects DepartmentSubjects { get; set; }

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

            return RedirectToPage("./Index");
        }
    }
}

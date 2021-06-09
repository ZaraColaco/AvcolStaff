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

namespace AvcolStaff.Pages.SubjectsS
{
    public class EditModel : PageModel
    {
        private readonly AvcolStaff.Data.AvcolStaffContext _context;

        public EditModel(AvcolStaff.Data.AvcolStaffContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Subjects Subjects { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Subjects = await _context.Subjects
                .Include(s => s.Departments).FirstOrDefaultAsync(m => m.SubjectsID == id);

            if (Subjects == null)
            {
                return NotFound();
            }
           ViewData["DepartmentsID"] = new SelectList(_context.Departments, "DepartmentsID", "DepartmentName");
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
            if (Subjects.SubjectName.Length != 5)
            {
                ViewData["DepartmentsID"] = new SelectList(_context.Departments, "DepartmentsID", "DepartmentName");
                ModelState.AddModelError("Custom", "Invalid Subject name (Please eneter a 0 before any single digit number e.g 09MAT)");
                return Page();
            }
            else
            {
                String[] validSubPart1 = { "09", "10", "11", "12", "13" };
                var subName = Subjects.SubjectName.Substring(0,2);
                if (validSubPart1.Contains(subName))
                {
                    char[] chars = Subjects.SubjectName.Substring(2, 3).ToCharArray();
                    foreach (char c in chars)
                    {
                        if (!char.IsLetter(c))
                        {

                            ViewData["DepartmentsID"] = new SelectList(_context.Departments, "DepartmentsID", "DepartmentName");
                            ModelState.AddModelError("Custom", "Please check that a three letter combination depicting the subject name follows the year level e.g 13MAT");
                            return Page();

                        }
                    }

                }
                else
                {
                    ViewData["DepartmentsID"] = new SelectList(_context.Departments, "DepartmentsID", "DepartmentName");
                    ModelState.AddModelError("Custom", "Invalid Subject name (Please eneter a 0 before any single digit number e.g 09MAT)");
                    return Page();

                }
                Subjects subject = (from t1 in _context.Subjects where t1.SubjectsID != Subjects.SubjectsID && t1.SubjectName == Subjects.SubjectName select t1).FirstOrDefault();
                if (subject != null)
                {
                    ViewData["DepartmentsID"] = new SelectList(_context.Departments, "DepartmentsID", "DepartmentName");
                    ModelState.AddModelError("Custom", "Subject already exists");
                    return Page();
                }
                _context.Attach(Subjects).State = EntityState.Modified;
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectsExists(Subjects.SubjectsID))
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

        private bool SubjectsExists(int id)
        {
            return _context.Subjects.Any(e => e.SubjectsID == id);
        }
    }
}

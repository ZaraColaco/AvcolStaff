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

namespace AvcolStaff.Pages.DepartmentStaffS
{
    public class EditModel : PageModel
    {
        private readonly AvcolStaff.Data.AvcolStaffContext _context;

        public EditModel(AvcolStaff.Data.AvcolStaffContext context)
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
           ViewData["DepartmentsID"] = new SelectList(_context.Departments, "DepartmentsID", "DepartmentName");
           ViewData["StaffID"] = new SelectList(_context.Staff, "StaffID", "FullName");
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
            DepartmentStaff staff = (from t1 in _context.DepartmentStaff
                                     where t1.StaffID == DepartmentStaff.StaffID
                                     && t1.DepartmentsID == DepartmentStaff.DepartmentsID
                                     select t1).FirstOrDefault();
            if (staff != null)
            {
                ViewData["DepartmentsID"] = new SelectList(_context.Departments, "DepartmentsID", "DepartmentName");
                ViewData["StaffID"] = new SelectList(_context.Subjects, "Staff", "FullName");
                ModelState.AddModelError("Custom", "Staff has already been asigned to the same department");
                return Page();
            }
            else
            {
                _context.DepartmentStaff.Add(DepartmentStaff);
                await _context.SaveChangesAsync();
            }
            _context.Attach(DepartmentStaff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentStaffExists(DepartmentStaff.DepartmentStaffID))
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

        private bool DepartmentStaffExists(int id)
        {
            return _context.DepartmentStaff.Any(e => e.DepartmentStaffID == id);
        }
    }
}

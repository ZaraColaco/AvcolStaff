using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AvcolStaff.Data;
using AvcolStaff.Models;

namespace AvcolStaff.Pages.DepartmentS
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
            return Page();
        }

        [BindProperty]
        public Departments Departments { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Departments department = (from t1 in _context.Departments where t1.DepartmentName==Departments.DepartmentName select t1).FirstOrDefault();
            _context.Departments.Add(Departments);
            if (department != null)
            {
                ModelState.AddModelError("Custom", "Department already exists");
                return Page();
            }
            else
            {
                _context.Departments.Add(Departments);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}

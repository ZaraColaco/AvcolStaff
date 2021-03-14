using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AvcolStaff.Data;
using AvcolStaff.Models;

namespace AvcolStaff.Pages.DepartmentS
{
    public class DetailsModel : PageModel
    {
        private readonly AvcolStaff.Data.AvcolStaffContext _context;

        public DetailsModel(AvcolStaff.Data.AvcolStaffContext context)
        {
            _context = context;
        }

        public Departments Departments { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Departments = await _context.Departments.FirstOrDefaultAsync(m => m.DepartmentsID == id);

            if (Departments == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

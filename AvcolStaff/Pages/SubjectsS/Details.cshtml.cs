using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AvcolStaff.Data;
using AvcolStaff.Models;

namespace AvcolStaff.Pages.SubjectsS
{
    public class DetailsModel : PageModel
    {
        private readonly AvcolStaff.Data.AvcolStaffContext _context;

        public DetailsModel(AvcolStaff.Data.AvcolStaffContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}

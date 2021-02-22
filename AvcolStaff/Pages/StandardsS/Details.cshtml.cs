using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AvcolStaff.Data;
using AvcolStaff.Models;

namespace AvcolStaff.Pages.StandardsS
{
    public class DetailsModel : PageModel
    {
        private readonly AvcolStaff.Data.AvcolStaffContext _context;

        public DetailsModel(AvcolStaff.Data.AvcolStaffContext context)
        {
            _context = context;
        }

        public Standards Standards { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Standards = await _context.Standards.FirstOrDefaultAsync(m => m.StandardsID == id);

            if (Standards == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

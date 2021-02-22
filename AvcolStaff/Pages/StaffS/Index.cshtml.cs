using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AvcolStaff.Data;
using AvcolStaff.Models;

namespace AvcolStaff.Pages.Staffs
{
    public class IndexModel : PageModel
    {
        private readonly AvcolStaff.Data.AvcolStaffContext _context;

        public IndexModel(AvcolStaff.Data.AvcolStaffContext context)
        {
            _context = context;
        }

        public IList<Staff> Staff { get;set; }

        public async Task OnGetAsync()
        {
            Staff = await _context.Staff.ToListAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AvcolStaff.Data;
using AvcolStaff.Models;

namespace AvcolStaff.Pages.StaffS
{
    public class IndexModel : PageModel
    {
        private readonly AvcolStaff.Data.AvcolStaffContext _context;

        public IndexModel(AvcolStaff.Data.AvcolStaffContext context)
        {
            _context = context;
        }
        public string NameSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public IList<Staff> Staff { get; set; }
        public async Task OnGetAsync(string sortOrder)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_ascend" : "";
            IQueryable<Staff> StaffFnameIQ = from s in _context.Staff
                                             select s;

            switch (sortOrder)
            {
                case "name_ascend":
                    StaffFnameIQ = StaffFnameIQ.OrderByDescending(s => s.LastName);
                    break;
                default:
                    StaffFnameIQ = StaffFnameIQ.OrderBy(s => s.LastName);
                    break;
            }

            Staff = await StaffFnameIQ.AsNoTracking().ToListAsync();
        }
       

       /* public async Task OnGetAsync()
        {
            Staff = await _context.Staff.ToListAsync();
        }*/
    }
}

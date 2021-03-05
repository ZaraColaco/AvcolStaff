using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AvcolStaff.Data;
using AvcolStaff.Models;

namespace AvcolStaff.Pages.PersonalInfoS
{
    public class IndexModel : PageModel
    {
        private readonly AvcolStaff.Data.AvcolStaffContext _context;

        public IndexModel(AvcolStaff.Data.AvcolStaffContext context)
        {
            _context = context;
        }

        public IList<PersonalInformation> PersonalInformation { get;set; }
        public string NameSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public IList<PersonalInformation> Staff { get; set; }
       /* public async Task OnGetAsync(string sortOrder)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_ascend" : "";
            IQueryable<PersonalInformation> StaffnameIQ = from s in _context.PersonalInformation
                                             select s;

            switch (sortOrder)
            {
                case "name_ascend":
                    StaffnameIQ = StaffnameIQ.OrderByDescending(s => s.FullName);
                    break;
                default:
                    StaffnameIQ = StaffnameIQ.OrderBy(s => s.FullName);
                    break;
            }

            PersonalInformation = await StaffnameIQ.AsNoTracking().ToListAsync();
        }*/
        public async Task OnGetAsync()
        {
            PersonalInformation = await _context.PersonalInformation
                .Include(p => p.Staff).ToListAsync();
        }
    }
}

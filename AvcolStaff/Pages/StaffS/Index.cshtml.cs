﻿using System;
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
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public IList<Staff> Staff { get; set; }
        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_ascend" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            CurrentFilter = searchString;
            IQueryable<Staff> StaffIQ = from s in _context.Staff
                                             select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                StaffIQ = StaffIQ.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_ascend":
                    StaffIQ = StaffIQ.OrderByDescending(s => s.LastName);
                    break;
                default:
                    StaffIQ = StaffIQ.OrderBy(s => s.LastName);
                    break;
                case "Date":
                    StaffIQ = StaffIQ.OrderBy(s => s.HireDate);
                    break;
                case "date_desc":
                    StaffIQ = StaffIQ.OrderByDescending(s => s.HireDate);
                    break;
            }

            Staff = await StaffIQ.AsNoTracking().ToListAsync();
        }
       

       /* public async Task OnGetAsync()
        {
            Staff = await _context.Staff.ToListAsync();
        }*/
    }
}

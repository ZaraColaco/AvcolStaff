using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AvcolStaff.Data;
using AvcolStaff.Models;

namespace AvcolStaff.Pages.DepartmentSubjectsS
{
    public class IndexModel : PageModel
    {
        private readonly AvcolStaff.Data.AvcolStaffContext _context;

        public IndexModel(AvcolStaff.Data.AvcolStaffContext context)
        {
            _context = context;
        }

        public IList<DepartmentSubjects> DepartmentSubjects { get;set; }

        public async Task OnGetAsync()
        {
            DepartmentSubjects = await _context.DepartmentSubjects
                .Include(d => d.Departments)
                .Include(d => d.Subjects).ToListAsync();
        }
    }
}

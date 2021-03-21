using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AvcolStaff.Data;
using AvcolStaff.Models;

namespace AvcolStaff.Pages.StaffS
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
        public Staff Staff { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        private DateTime CheckDate = new DateTime(1985,01,01);
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var staffName = (from t1 in _context.Staff
                             where t1.FirstName == Staff.FirstName && t1.LastName == Staff.LastName
                             select t1).FirstOrDefault();
            if (staffName != null)
            {
                ModelState.AddModelError("Custom", " Staff already exists");
                return Page();
            }
            var LName = Staff.LastName;
            var TCode = Staff.FirstName.Substring(0,1).ToUpper();
            var TeacherCD = " ";
            Staff staff = null;
            for (int i =0; i< LName.Length-1;i++)
            {
                TeacherCD = TCode + LName.Substring(i, 2).ToUpper();
                 staff = (from t1 in _context.Staff
                                 where t1.TeacherCode == TeacherCD 
                                 select t1).FirstOrDefault();
                if (staff == null)
                {
                    break;
                }

            }
           /* if (staff != null)
            {
                TeacherCD= Staff.FirstName
            }*/
            Staff.TeacherCode = TeacherCD;
            if (Staff.HireDate > DateTime.Now || Staff.HireDate < CheckDate)
            {
                ModelState.AddModelError("Custom", "Invalid Hire date");
                return Page();
            }

            _context.Staff.Add(Staff);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

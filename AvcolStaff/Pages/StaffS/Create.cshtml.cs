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
                             select t1).FirstOrDefault();//Checks if a staff with the same fist and last name already exists
            if (staffName != null)
            {
                ModelState.AddModelError("Custom", " Staff already exists");//Displays error message
                return Page();
            }
            var LName = Staff.LastName;
            var TeacherCD = " ";
            Staff staff = null;
            for (int f = 0; f < Staff.FirstName.Length; f++)////Loop through the first name untill the end is reached
            {
                var TCode = Staff.FirstName.Substring(f, 1).ToUpper();//First letter of the First name in uppercase
                for (int i = 0; i < LName.Length - 1; i++)//for every pair of letters in the last name keeping checking untill a unique combination of letters is achievied 
                {
                    TeacherCD = TCode + LName.Substring(i, 2).ToUpper();
                    staff = (from t1 in _context.Staff
                             where t1.TeacherCode == TeacherCD
                             select t1).FirstOrDefault();
                    if (staff == null)//if its unique staff == null  otherwise take the next pair of letters in the last name
                    {
                        break;
                    }

                }
                if (staff == null)//No occurences of that teacher code in the the database if staff == null  otherwise take the next pair of letters in the first name
                {
                    break;
                }
            }
            if (staff != null)//At this point if a uniwue combination has still no been achieved 
            {
                for (int i = 0; i < LName.Length - 1; i++)//Loop through the last name untill the end is reached
                {
                    TeacherCD = "X" + LName.Substring(i, 2).ToUpper();//starting with X add a pair of letters from the last name untill a unique combination in formed
                    staff = (from t1 in _context.Staff
                             where t1.TeacherCode == TeacherCD
                             select t1).FirstOrDefault();
                    if (staff == null)//realistically at this point a unique code would have been formed already so the loop can break without need for further cases. 
                    {
                        break;
                    }
                }
            }
            Staff.TeacherCode = TeacherCD;//sets the value of the teacher code
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

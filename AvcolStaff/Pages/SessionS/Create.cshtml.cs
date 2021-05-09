using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AvcolStaff.Data;
using AvcolStaff.Models;

namespace AvcolStaff.Pages.SessionS
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
        ViewData["StaffID"] = new SelectList(_context.Staff, "StaffID", "FullName");
        ViewData["SubjectsID"] = new SelectList(_context.Subjects, "SubjectsID", "SubjectName");
            return Page();
        }

        [BindProperty]
        public Sessions Sessions { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            int sessSub = Sessions.SubjectsID;
            int sessStaff = Sessions.StaffID;
            int deptSub = (from t1 in _context.DepartmentSubjects
                           where t1.SubjectsID == sessSub// identifier comparison 
                           select t1.DepartmentsID).FirstOrDefault();
            var query = 0;
            if (deptSub > 0)
            {
                query = (from t2 in _context.DepartmentStaff
                         where t2.StaffID == sessStaff
                         && t2.DepartmentsID == deptSub
                         select t2.DepartmentsID).FirstOrDefault();
            }
            if (query == 0 || deptSub == 0)
            {
                ViewData["StaffID"] = new SelectList(_context.Staff, "StaffID", "FullName");
                ViewData["SubjectsID"] = new SelectList(_context.Subjects, "SubjectsID", "SubjectName");
                ModelState.AddModelError("Custom", " This Staff has not been assigned to Department of the subject you selected ");
                return Page();

            }
            Sessions teacher = (from t1 in _context.Sessions where t1.StaffID == Sessions.StaffID && t1.Day == Sessions.Day && t1.Period == Sessions.Period select t1).FirstOrDefault();
            if (teacher != null)
            {
                ViewData["StaffID"] = new SelectList(_context.Staff, "StaffID", "FullName");
                ViewData["SubjectsID"] = new SelectList(_context.Subjects, "SubjectsID", "SubjectName");
                ModelState.AddModelError("Custom", "Staff is booked for another class at this time. Please choose another staff or try changing the time");
                return Page();
            }
            Sessions room = (from t1 in _context.Sessions where t1.RoomNumber == Sessions.RoomNumber && t1.Day == Sessions.Day && t1.Period == Sessions.Period select t1).FirstOrDefault();
            if (room != null)
            {
                ViewData["StaffID"] = new SelectList(_context.Staff, "StaffID", "FullName");
                ViewData["SubjectsID"] = new SelectList(_context.Subjects, "SubjectsID", "SubjectName");
                ModelState.AddModelError("Custom", "This room is occupied at this time. Please choose another room");
                return Page();
            }

            _context.Sessions.Add(Sessions);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}


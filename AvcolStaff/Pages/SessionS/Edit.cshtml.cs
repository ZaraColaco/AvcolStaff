using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AvcolStaff.Data;
using AvcolStaff.Models;

namespace AvcolStaff.Pages.SessionS
{
    public class EditModel : PageModel
    {
        private readonly AvcolStaff.Data.AvcolStaffContext _context;

        public EditModel(AvcolStaff.Data.AvcolStaffContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sessions Sessions { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sessions = await _context.Sessions
                .Include(s => s.Staff)
                .Include(s => s.Subjects).FirstOrDefaultAsync(m => m.SessionsID == id);

            if (Sessions == null)
            {
                return NotFound();
            }
           ViewData["StaffID"] = new SelectList(_context.Staff, "StaffID", "FullName");
           ViewData["SubjectsID"] = new SelectList(_context.Subjects, "SubjectsID", "SubjectName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var sessId = Sessions.SessionsID;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            int sessSub = Sessions.SubjectsID;
            int sessStaff = Sessions.StaffID;
            int deptSub = (from t1 in _context.Subjects
                           where t1.SubjectsID == sessSub// any identifier comparison can be done here
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
            Sessions teacher = (from t1 in _context.Sessions where t1.SessionsID != Sessions.SessionsID && t1.StaffID == Sessions.StaffID && t1.Day == Sessions.Day && t1.Period == Sessions.Period select t1).FirstOrDefault();
            if (teacher != null)
            {
                ViewData["StaffID"] = new SelectList(_context.Staff, "StaffID", "FullName");
                ViewData["SubjectsID"] = new SelectList(_context.Subjects, "SubjectsID", "SubjectName");
                ModelState.AddModelError("Custom", "Staff is booked for another class at this time. Please choose another staff or try changing the time");
                return Page();
            }
            String[] validRoomPart1 = { "A", "B", "C", "D", "E", "F" };
            bool validRoom = true;
            var roomName = Sessions.RoomNumber.Substring(0, 1);
            if (validRoomPart1.Contains(roomName))
            {
                char[] chars = Sessions.RoomNumber.Substring(1, Sessions.RoomNumber.Length - 1).ToCharArray();
                int roomNum = Int32.Parse(Sessions.RoomNumber.Substring(1, Sessions.RoomNumber.Length - 1));
                foreach (char c in chars)
                {
                    if (!char.IsDigit(c))
                    {
                        validRoom = false;
                    }
                    else if (roomName == "A")
                    {
                        if (roomNum < 1 || roomNum > 46)
                        {
                            validRoom = false;
                        }
                        else
                        {
                            validRoom = true;
                            break;
                        }
                    }
                    else if (roomName == "B")
                    {
                        if (roomNum < 1 || roomNum > 17)
                        {
                            validRoom = false;
                        }
                        else
                        {
                            validRoom = true;
                            break;
                        }
                    }
                    else if (roomName == "C")
                    {
                        if (roomNum < 1 || roomNum > 29)
                        {
                            validRoom = false;
                        }
                        else
                        {
                            validRoom = true;
                            break;
                        }
                    }
                    else if (roomName == "D")
                    {
                        if (roomNum < 1 || roomNum > 29)
                        {
                            validRoom = false;
                        }
                        else
                        {
                            validRoom = true;
                            break;
                        }
                    }
                    else if (roomName == "E")
                    {
                        if (roomNum < 1 || roomNum > 12)
                        {
                            validRoom = false;
                        }
                        else
                        {
                            validRoom = true;
                            break;
                        }
                    }
                    else if (roomName == "F")
                    {
                        if (roomNum < 1 && roomNum > 14)
                        {
                            validRoom = false;
                        }
                        else
                        {
                            validRoom = true;
                            break;
                        }
                    }

                }
            }
            else
            {
                validRoom = false;
            }
            if (validRoom == false)
            {
                ViewData["StaffID"] = new SelectList(_context.Staff, "StaffID", "FullName");
                ViewData["SubjectsID"] = new SelectList(_context.Subjects, "SubjectsID", "SubjectName");
                ModelState.AddModelError("Custom", "Invalid Room Name e.g A46");
                return Page();
            }
            Sessions room = (from t1 in _context.Sessions where t1.SessionsID != Sessions.SessionsID && t1.RoomNumber == Sessions.RoomNumber && t1.Day == Sessions.Day && t1.Period == Sessions.Period select t1).FirstOrDefault();
            if (room != null)
            {
                ViewData["StaffID"] = new SelectList(_context.Staff, "StaffID", "FullName");
                ViewData["SubjectsID"] = new SelectList(_context.Subjects, "SubjectsID", "SubjectName");
                ModelState.AddModelError("Custom", "This room is occupied at this time. Please choose another room");
                return Page();
            }
            else
            {
                _context.Sessions.Add(Sessions);
                await _context.SaveChangesAsync();
            }

            _context.Attach(Sessions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SessionsExists(Sessions.StaffID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SessionsExists(int id)
        {
            return _context.Sessions.Any(e => e.StaffID == id);
        }
    }
}


﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AvcolStaff.Data;
using AvcolStaff.Models;

namespace AvcolStaff.Pages.StaffS
{
    public class EditModel : PageModel
    {
        private readonly AvcolStaff.Data.AvcolStaffContext _context;

        public EditModel(AvcolStaff.Data.AvcolStaffContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Staff Staff { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Staff = await _context.Staff.FirstOrDefaultAsync(m => m.StaffID == id);

            if (Staff == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        private DateTime CheckDate = new DateTime(1985, 01, 01);
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
            var TCode = Staff.FirstName.Substring(0, 1).ToUpper();
            var TeacherCD = " ";
            Staff staff = null;
            for (int i = 0; i < LName.Length - 1; i++)
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
            if (staffName != null)
            {
                ModelState.AddModelError("Custom", " Staff already exists");
                return Page();
            }
            if (Staff.HireDate > DateTime.Now || Staff.HireDate < CheckDate)
            {
                ModelState.AddModelError("Custom", "Invalid Hire date");
                return Page();
            }
            _context.Attach(Staff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffExists(Staff.StaffID))
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

        private bool StaffExists(int id)
        {
            return _context.Staff.Any(e => e.StaffID == id);
        }
    }
}

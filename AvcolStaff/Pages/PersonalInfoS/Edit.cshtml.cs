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

namespace AvcolStaff.Pages.PersonalInfoS
{
    public class EditModel : PageModel
    {
        private readonly AvcolStaff.Data.AvcolStaffContext _context;

        public EditModel(AvcolStaff.Data.AvcolStaffContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PersonalInformation PersonalInformation { get; set; }
        [BindProperty]
        public int CitizenStatus { get; set; }
        [BindProperty]
        public int Ethnicity { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PersonalInformation = await _context.PersonalInformation
                .Include(p => p.Staff).FirstOrDefaultAsync(m => m.StaffID == id);

            if (PersonalInformation == null)
            {
                return NotFound();
            }
            ViewData["StaffID"] = new SelectList(_context.Staff, "StaffID", "FullName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        private DateTime EarlyDate = new DateTime(1950, 01, 01);
        private DateTime LateDate = new DateTime(1999, 01, 01);
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (PersonalInformation.DateOfBirth < EarlyDate || PersonalInformation.DateOfBirth > LateDate)
            {
                ModelState.AddModelError("Custom", "Invalid Date of Birth");
                return Page();
            }
            if (PersonalInformation.PhoneNumber.Length != 10)
            {
                ViewData["StaffID"] = new SelectList(_context.Staff, "StaffID", "FullName");
                ModelState.AddModelError("Custom", "Invalid Phone Number");
                return Page();
            }
            if (PersonalInformation.EmergencyContact.Length != 10)
            {
                ViewData["StaffID"] = new SelectList(_context.Staff, "StaffID", "FullName");
                ModelState.AddModelError("Custom", "Invalid Emergency Contact Number");
                return Page();
            }
            _context.Attach(PersonalInformation).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalInformationExists(PersonalInformation.StaffID))
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

        private bool PersonalInformationExists(int id)
        {
            return _context.PersonalInformation.Any(e => e.StaffID == id);
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AvcolStaff.Data;
using AvcolStaff.Models;

namespace AvcolStaff.Pages.PersonalInfoS
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
            return Page();
        }

        [BindProperty]
        public PersonalInformation PersonalInformation { get; set; }
        [BindProperty]
        public int CitizenStatus { get; set; }
        [BindProperty]
        public int Ethnicity { get; set; }

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
                ViewData["StaffID"] = new SelectList(_context.Staff, "StaffID", "FirstName");
                ModelState.AddModelError("Custom", "Invalid Date of Birth");
                return Page();
            }
            if (!ModelState.IsValid)
            {
                ViewData["StaffID"] = new SelectList(_context.Staff, "StaffID", "FirstName");
                return Page();
            }

            if (!PersonalInformation.EmailAddress.EndsWith("@avcol.school.nz"))
            {
                ViewData["StaffID"] = new SelectList(_context.Staff, "StaffID", "FirstName");
                ModelState.AddModelError("Custom", "Email Domain is incorrect please enter an email address with the correct avcol domain");
                return Page();
            }
            PersonalInformation pInfo = (from t1 in _context.PersonalInformation where t1.StaffID == PersonalInformation.StaffID select t1).FirstOrDefault();
            if (pInfo != null)
            {
                ViewData["StaffID"] = new SelectList(_context.Staff, "StaffID", "FullName");
                ModelState.AddModelError("Custom", "This Staff has already has a record of their personal information, please edit the existing one.");
                return Page();
            }
            else
            {
                _context.PersonalInformation.Add(PersonalInformation);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}

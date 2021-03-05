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
    public class DeleteModel : PageModel
    {
        private readonly AvcolStaff.Data.AvcolStaffContext _context;

        public DeleteModel(AvcolStaff.Data.AvcolStaffContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PersonalInformation PersonalInformation { get; set; }

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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PersonalInformation = await _context.PersonalInformation.FindAsync(id);

            if (PersonalInformation != null)
            {
                _context.PersonalInformation.Remove(PersonalInformation);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

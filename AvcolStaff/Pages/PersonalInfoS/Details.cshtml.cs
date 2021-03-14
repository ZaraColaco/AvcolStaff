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
    public class DetailsModel : PageModel
    {
        private readonly AvcolStaff.Data.AvcolStaffContext _context;
        public string CitizenS;
        public DetailsModel(AvcolStaff.Data.AvcolStaffContext context)
        {
            _context = context;
        }

        public PersonalInformation PersonalInformation { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (PersonalInformation.CitizenStatus == "1")
            {
                CitizenS = "NZ Citizen";
            }
            else
            {
                CitizenS = "Other";
            }
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
    }
}

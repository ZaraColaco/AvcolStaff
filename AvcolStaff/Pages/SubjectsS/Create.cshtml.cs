using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AvcolStaff.Data;
using AvcolStaff.Models;

namespace AvcolStaff.Pages.SubjectsS
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
        public Subjects Subjects { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Subjects subject = (from t1 in _context.Subjects where t1.SubjectName == Subjects.SubjectName select t1).FirstOrDefault();
            _context.Subjects.Add(Subjects);
            if (subject != null)
            {
                ModelState.AddModelError("Custom", "Subject already exists");
                return Page();
            }
            else
            {
                _context.Subjects.Add(Subjects);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
            
    }
}


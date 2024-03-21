using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Pages.Lectures
{
    public class CreateModel : PageModel
    {
        private readonly StudentManagementSystem.Models.PRN221_StudentManagementSystemContext _context;

        public CreateModel(StudentManagementSystem.Models.PRN221_StudentManagementSystemContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
       
            return Page();
        }

        [BindProperty]
        public Lecture Lecture { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Lectures == null || Lecture == null)
            {
                return Page();
            }

            _context.Lectures.Add(Lecture);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Pages.ClassSubjects
{
    public class DeleteModel : PageModel
    {
        private readonly StudentManagementSystem.Models.PRN221_StudentManagementSystemContext _context;

        public DeleteModel(StudentManagementSystem.Models.PRN221_StudentManagementSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ClassSubject ClassSubject { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.ClassSubjects == null)
            {
                return NotFound();
            }

            var classsubject = await _context.ClassSubjects.FirstOrDefaultAsync(m => m.ClassSubjectId == id);

            if (classsubject == null)
            {
                return NotFound();
            }
            else 
            {
                ClassSubject = classsubject;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.ClassSubjects == null)
            {
                return NotFound();
            }
            var classsubject = await _context.ClassSubjects.FindAsync(id);

            if (classsubject != null)
            {
                ClassSubject = classsubject;
                _context.ClassSubjects.Remove(ClassSubject);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

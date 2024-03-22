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

        public async Task<IActionResult> OnGetAsync(string id, int classId, string subjectId)
        {
            if (id == null || _context.ClassSubjects == null || classId == 0 || subjectId == null)
            {
                return NotFound();
            }

            var classsubject = await _context.ClassSubjects.FirstOrDefaultAsync(m => m.ClassSubjectId == id && m.ClassId == classId && m.SubjectId == subjectId);

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

        public async Task<IActionResult> OnPostAsync(string id, string subjectId, int classId)
        {
            if (id == null || _context.ClassSubjects == null || subjectId == null || classId == 0)
            {
                return NotFound();
            }
            var classsubject = await _context.ClassSubjects.FirstOrDefaultAsync(m => m.ClassSubjectId == id && m.ClassId == classId && m.SubjectId == subjectId);

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

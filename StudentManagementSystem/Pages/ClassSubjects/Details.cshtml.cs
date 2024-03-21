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
    public class DetailsModel : PageModel
    {
        private readonly StudentManagementSystem.Models.PRN221_StudentManagementSystemContext _context;

        public DetailsModel(StudentManagementSystem.Models.PRN221_StudentManagementSystemContext context)
        {
            _context = context;
        }

      public ClassSubject ClassSubject { get; set; } = default!; 
        public List<Student> Students { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string? subjectId, int? classId)
        {
            if (subjectId == null || _context.ClassSubjects == null || classId == null)
            {
                return NotFound();
            }
            Students = await _context.Students.Where(x => x.ClassId == classId).ToListAsync();
            ViewData["ClassId"] = classId;
            return Page();
        }
    }
}

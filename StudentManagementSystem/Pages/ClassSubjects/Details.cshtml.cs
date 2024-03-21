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
    }
}

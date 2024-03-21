using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Pages.StudentExercise
{
    public class DetailsModel : PageModel
    {
        private readonly StudentManagementSystem.Models.PRN221_StudentManagementSystemContext _context;

        public DetailsModel(StudentManagementSystem.Models.PRN221_StudentManagementSystemContext context)
        {
            _context = context;
        }

      public StudentsExcercy StudentsExcercy { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.StudentsExcercies == null)
            {
                return NotFound();
            }

            var studentsexcercy = await _context.StudentsExcercies.FirstOrDefaultAsync(m => m.StudentId == id);
            if (studentsexcercy == null)
            {
                return NotFound();
            }
            else 
            {
                StudentsExcercy = studentsexcercy;
            }
            return Page();
        }
    }
}

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
    public class IndexModel : PageModel
    {
        private readonly StudentManagementSystem.Models.PRN221_StudentManagementSystemContext _context;

        public IndexModel(StudentManagementSystem.Models.PRN221_StudentManagementSystemContext context)
        {
            _context = context;
        }

        public IList<StudentsExcercy> StudentsExcercy { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
           
            int? roleId = HttpContext?.Session.GetInt32("RoleId");
            string studentId = HttpContext?.Session.GetString("StudentId");

            if(roleId == 0 && studentId == null)
            {
                return Redirect("/login");
            }
            if (_context.StudentsExcercies != null)
            {
                StudentsExcercy = await _context.StudentsExcercies
                .Include(s => s.ExerciseNameNavigation)
                .Include(s => s.Student).ToListAsync();
                if(studentId != null)
                {
                    StudentsExcercy = await _context.StudentsExcercies
               .Include(s => s.ExerciseNameNavigation)
               .Include(s => s.Student).Where(x => x.StudentId == studentId).ToListAsync();
                }

            }
            return Page();
        }
    }
}

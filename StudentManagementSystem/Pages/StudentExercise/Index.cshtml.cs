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
        private readonly PRN221_StudentManagementSystemContext _context;

        public IndexModel(PRN221_StudentManagementSystemContext context)
        {
            _context = context;
        }

        public IList<StudentsExcercy> StudentsExcercy { get; set; } = default!;
        [BindProperty(SupportsGet = true, Name = "ipp")]
        public int ItemsPerPage { get; set; } = 10;

        [BindProperty(SupportsGet = true, Name = "p")]
        public int currentPage { get; set; }

        public int countPages { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            int? roleId = HttpContext?.Session.GetInt32("RoleId");
            string studentId = HttpContext?.Session.GetString("StudentId");

            if (roleId == 0 && studentId == null)
            {
                return Redirect("/login");
            }

            IQueryable<StudentsExcercy> query = _context.StudentsExcercies
                .Include(s => s.ExerciseNameNavigation)
                .Include(s => s.Student);

            if (studentId != null)
            {
                query = query.Where(x => x.StudentId == studentId);
            }

            int totalItems = await query.CountAsync();
            countPages = (int)Math.Ceiling((double)totalItems / ItemsPerPage);

            currentPage = Math.Clamp(currentPage, 1, countPages);

            StudentsExcercy = await query
                .Skip((currentPage - 1) * ItemsPerPage)
                .Take(ItemsPerPage)
                .ToListAsync();

            return Page();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Pages.StudentExamSchedule
{
    public class IndexModel : PageModel
    {
        private readonly PRN221_StudentManagementSystemContext _context;

        public IndexModel(PRN221_StudentManagementSystemContext context)
        {
            _context = context;
        }

        public List<ExamSchedule> ExamSchedules { get; set; } = new List<ExamSchedule>();
        [BindProperty(SupportsGet = true, Name = "ipp")]
        public int ItemsPerPage { get; set; } = 10;
        [BindProperty(SupportsGet = true, Name = "p")]
        public int CurrentPage { get; set; } = 1;
        public int countPages { get; set; }
      

        public async Task OnGetAsync()
        {
            string studentId = HttpContext?.Session.GetString("StudentId");
            ViewData["StudentId"] = studentId;

            IQueryable<ExamSchedule> query = _context.ExamSchedules
                .Include(e => e.Lecture)
                .Include(e => e.Semester)
                .Include(e => e.Subject);

            if (!string.IsNullOrEmpty(studentId))
            {
                query = query.Where(x => x.Students.Any(s => s.StudentId == studentId));
            }

            int totalExams = await query.CountAsync();
            countPages = (int)Math.Ceiling((double)totalExams / ItemsPerPage);
            CurrentPage = Math.Max(CurrentPage, 1);

            ExamSchedules = await query
                .Skip((CurrentPage - 1) * ItemsPerPage)
                .Take(ItemsPerPage)
                .ToListAsync();
        }
    }
}

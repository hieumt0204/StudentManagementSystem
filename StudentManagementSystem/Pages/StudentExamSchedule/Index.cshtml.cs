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

        public List<ExamSchedule> ExamSchedules { get; set; }

        public async Task OnGetAsync()
        {
            string studentId = HttpContext?.Session.GetString("StudentId");
            ViewData["StudentId"] = studentId;

            if (!string.IsNullOrEmpty(studentId))
            {
                // Lấy ra danh sách các kế hoạch thi của sinh viên dựa trên studentId
                var studentExamSchedule = await _context.ExamSchedules
                    .Include(x => x.Students)
                       .Include(e => e.Lecture)
                        .Include(e => e.Semester)
                        .Include(e => e.Subject)
                    .Where(x => x.Students.Any(s => s.StudentId == studentId))
                    .ToListAsync();

                ExamSchedules = studentExamSchedule;
            }
            else
            {
                ExamSchedules = await _context.ExamSchedules
                    .Include(e => e.Lecture)
                    .Include(e => e.Semester)
                    .Include(e => e.Subject)
                    .ToListAsync();  
            }
        }
    }
}

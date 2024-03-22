using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Pages.ExamSchedules
{
    public class IndexModel : PageModel
    {
        private readonly PRN221_StudentManagementSystemContext _context;

        public IndexModel(PRN221_StudentManagementSystemContext context)
        {
            _context = context;
        }

        public IList<ExamSchedule> ExamSchedule { get; set; } = new List<ExamSchedule>();
        [BindProperty(SupportsGet = true, Name = "ipp")]
        public int ItemsPerPage { get; set; } = 10;

        [BindProperty(SupportsGet = true, Name = "p")]
        public int CurrentPage { get; set; }

        public int CountPages { get; set; }

        public async Task OnGetAsync()
        {
            string lecturerId = HttpContext?.Session.GetString("LectureId");
            int? roleId = HttpContext?.Session.GetInt32("RoleId");
            ViewData["RoleId"] = roleId;

            IQueryable<ExamSchedule> query = _context.ExamSchedules
                .Include(e => e.Lecture)
                .Include(e => e.Semester)
                .Include(e => e.Subject);

            if (query != null)
            {
                ExamSchedule = await query.ToListAsync();

                if (lecturerId != null)
                {
                    ExamSchedule = await query
                        .Where(e => e.LectureId == lecturerId)
                        .ToListAsync();
                }

                int totalExamSchedules = ExamSchedule.Count;
                CountPages = (int)Math.Ceiling((double)totalExamSchedules / ItemsPerPage);

                if (CurrentPage < 1)
                    CurrentPage = 1;
                if (CurrentPage > CountPages)
                    CurrentPage = CountPages;
                CurrentPage = Math.Max(CurrentPage, 1);

                ExamSchedule = await query
                    .OrderBy(e => e.Date)
                    .Skip((CurrentPage - 1) * ItemsPerPage)
                    .Take(ItemsPerPage)
                    .ToListAsync();
            }
        }
    }
}

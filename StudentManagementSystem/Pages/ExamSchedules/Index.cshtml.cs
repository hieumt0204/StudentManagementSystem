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
        private readonly StudentManagementSystem.Models.PRN221_StudentManagementSystemContext _context;

        public IndexModel(StudentManagementSystem.Models.PRN221_StudentManagementSystemContext context)
        {
            _context = context;
        }

        public IList<ExamSchedule> ExamSchedule { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ExamSchedules != null)
            {
                ExamSchedule = await _context.ExamSchedules
                .Include(e => e.Lecture)
                .Include(e => e.Semester)
                .Include(e => e.Subject).
                ToListAsync();
            }
        }
    }
}

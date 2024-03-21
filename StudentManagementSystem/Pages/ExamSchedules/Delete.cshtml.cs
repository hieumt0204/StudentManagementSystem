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
    public class DeleteModel : PageModel
    {
        private readonly StudentManagementSystem.Models.PRN221_StudentManagementSystemContext _context;

        public DeleteModel(StudentManagementSystem.Models.PRN221_StudentManagementSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ExamSchedule ExamSchedule { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ExamSchedules == null)
            {
                return NotFound();
            }

            var examschedule = await _context.ExamSchedules.FirstOrDefaultAsync(m => m.ExamScheduleId == id);

            if (examschedule == null)
            {
                return NotFound();
            }
            else 
            {
                ExamSchedule = examschedule;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ExamSchedules == null)
            {
                return NotFound();
            }
            var examschedule = await _context.ExamSchedules.FindAsync(id);

            if (examschedule != null)
            {
                ExamSchedule = examschedule;
                _context.ExamSchedules.Remove(ExamSchedule);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

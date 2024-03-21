using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Pages.ExamSchedules
{
    public class EditModel : PageModel
    {
        private readonly StudentManagementSystem.Models.PRN221_StudentManagementSystemContext _context;

        public EditModel(StudentManagementSystem.Models.PRN221_StudentManagementSystemContext context)
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

            var examschedule =  await _context.ExamSchedules.FirstOrDefaultAsync(m => m.ExamScheduleId == id);
            if (examschedule == null)
            {
                return NotFound();
            }
            ExamSchedule = examschedule;
           ViewData["LectureId"] = new SelectList(_context.Lectures, "LectureId", "LectureId");
           ViewData["SemesterId"] = new SelectList(_context.Semesters, "SemesterId", "SemesterId");
           ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ExamSchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamScheduleExists(ExamSchedule.ExamScheduleId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ExamScheduleExists(int id)
        {
          return (_context.ExamSchedules?.Any(e => e.ExamScheduleId == id)).GetValueOrDefault();
        }
    }
}

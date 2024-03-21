using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Pages.ExamSchedules
{
    public class CreateModel : PageModel
    {
        private readonly StudentManagementSystem.Models.PRN221_StudentManagementSystemContext _context;

        public CreateModel(StudentManagementSystem.Models.PRN221_StudentManagementSystemContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["LectureId"] = new SelectList(_context.Lectures, "LectureId", "LectureId");
        ViewData["SemesterId"] = new SelectList(_context.Semesters, "SemesterId", "SemesterId");
        ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId");
            return Page();
        }

        [BindProperty]
        public ExamSchedule ExamSchedule { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ExamSchedules == null || ExamSchedule == null)
            {
                return Page();
            }

            _context.ExamSchedules.Add(ExamSchedule);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

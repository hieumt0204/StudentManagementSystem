using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Pages.ClassSubjects
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
        ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassId");
        ViewData["LectureId"] = new SelectList(_context.Lectures, "LectureId", "LectureId");
        ViewData["Room"] = new SelectList(_context.Rooms, "RoomId", "RoomId");
        ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId");
            return Page();
        }

        [BindProperty]
        public ClassSubject ClassSubject { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ClassSubjects == null || ClassSubject == null)
            {
                return Page();
            }

            _context.ClassSubjects.Add(ClassSubject);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

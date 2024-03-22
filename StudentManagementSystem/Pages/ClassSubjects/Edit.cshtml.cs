using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Pages.ClassSubjects
{
    public class EditModel : PageModel
    {
        private readonly StudentManagementSystem.Models.PRN221_StudentManagementSystemContext _context;

        public EditModel(StudentManagementSystem.Models.PRN221_StudentManagementSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ClassSubject ClassSubject { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id, string subjectId, int classId)
        {
            if (id == null || _context.ClassSubjects == null || subjectId == null || classId == 0)
            {
                return NotFound();
            }

            var classsubject =  await _context.ClassSubjects.FirstOrDefaultAsync(m => m.ClassSubjectId == id && m.SubjectId == subjectId && m.ClassId == classId);
            if (classsubject == null)
            {
                return NotFound();
            }
            ClassSubject = classsubject;
           ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassClassName");
           ViewData["LectureId"] = new SelectList(_context.Lectures, "LectureId", "LectureId");
           ViewData["Room"] = new SelectList(_context.Rooms, "RoomId", "RoomId");
           ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
           

            _context.Attach(ClassSubject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassSubjectExists(ClassSubject.ClassSubjectId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new { ClassSubject.SubjectId}) ;
        }

        private bool ClassSubjectExists(string id)
        {
          return (_context.ClassSubjects?.Any(e => e.ClassSubjectId == id)).GetValueOrDefault();
        }
    }
}

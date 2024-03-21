using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Pages.StudentExercise
{
    public class EditModel : PageModel
    {
        private readonly StudentManagementSystem.Models.PRN221_StudentManagementSystemContext _context;

        public EditModel(StudentManagementSystem.Models.PRN221_StudentManagementSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StudentsExcercy StudentsExcercy { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.StudentsExcercies == null)
            {
                return NotFound();
            }

            var studentsexcercy =  await _context.StudentsExcercies.FirstOrDefaultAsync(m => m.StudentId == id);
            if (studentsexcercy == null)
            {
                return NotFound();
            }
            StudentsExcercy = studentsexcercy;
           ViewData["ExerciseName"] = new SelectList(_context.Excercies, "ExerciseName", "ExerciseName");
           ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId");
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

            _context.Attach(StudentsExcercy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentsExcercyExists(StudentsExcercy.StudentId))
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

        private bool StudentsExcercyExists(string id)
        {
          return (_context.StudentsExcercies?.Any(e => e.StudentId == id)).GetValueOrDefault();
        }
    }
}

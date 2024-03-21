using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Pages.Exercises
{
    public class EditModel : PageModel
    {
        private readonly StudentManagementSystem.Models.PRN221_StudentManagementSystemContext _context;

        public EditModel(StudentManagementSystem.Models.PRN221_StudentManagementSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Excercy Excercy { get; set; } = default!;
        [BindProperty]
        public string SubjectId { get; set; }

        public async Task<IActionResult> OnGetAsync(string id, string subjectId)
        {
            if (id == null || _context.Excercies == null)
            {
                return NotFound();
            }

            var excercy =  await _context.Excercies.FirstOrDefaultAsync(m => m.ExerciseName == id);
            if (excercy == null)
            {
                return NotFound();
            }
            Excercy = excercy;
           ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string id, string subjectId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Excercy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExcercyExists(Excercy.ExerciseName))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new {SubjectId = subjectId });
        }

        private bool ExcercyExists(string id)
        {
          return (_context.Excercies?.Any(e => e.ExerciseName == id)).GetValueOrDefault();
        }
    }
}

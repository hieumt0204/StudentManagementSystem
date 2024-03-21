using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Pages.Exercises
{
    public class DeleteModel : PageModel
    {
        private readonly StudentManagementSystem.Models.PRN221_StudentManagementSystemContext _context;

        public DeleteModel(StudentManagementSystem.Models.PRN221_StudentManagementSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Excercy Excercy { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Excercies == null)
            {
                return NotFound();
            }

            var excercy = await _context.Excercies.FirstOrDefaultAsync(m => m.ExerciseName == id);

            if (excercy == null)
            {
                return NotFound();
            }
            else 
            {
                Excercy = excercy;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.Excercies == null)
            {
                return NotFound();
            }
            var excercy = await _context.Excercies.FindAsync(id);

            if (excercy != null)
            {
                Excercy = excercy;
                _context.Excercies.Remove(Excercy);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

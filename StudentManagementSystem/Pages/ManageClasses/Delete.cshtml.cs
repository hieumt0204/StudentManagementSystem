using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;
using System.Threading.Tasks;

namespace StudentManagementSystem.Pages.ManageClasses
{
    public class DeleteModel : PageModel
    {
        private readonly PRN221_StudentManagementSystemContext _context;

        public DeleteModel(PRN221_StudentManagementSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Class Class { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Class = await _context.Classes.FirstOrDefaultAsync(m => m.ClassId == id);

            if (Class == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Class = await _context.Classes.FindAsync(id);

            if (Class != null)
            {
                _context.Classes.Remove(Class);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
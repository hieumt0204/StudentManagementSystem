using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentManagementSystem.Models;
using System.Threading.Tasks;

namespace StudentManagementSystem.Pages.ManageClasses
{
    public class CreateModel : PageModel
    {
        private readonly PRN221_StudentManagementSystemContext _context;

        public CreateModel(PRN221_StudentManagementSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Class Class { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Classes.Add(Class);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Pages.Lectures
{

    public class IndexModel : PageModel
    {
        private readonly StudentManagementSystem.Models.PRN221_StudentManagementSystemContext _context;

        public IndexModel(StudentManagementSystem.Models.PRN221_StudentManagementSystemContext context)
        {
            _context = context;
        }

        public IList<Lecture> Lecture { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Lectures != null)
            {
                Lecture = await _context.Lectures
                .ToListAsync();
            }
        }
    }
}

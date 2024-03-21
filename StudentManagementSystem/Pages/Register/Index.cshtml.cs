using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Pages.Register
{
    public class IndexModel : PageModel
    {
        private readonly PRN221_StudentManagementSystemContext _context;
        public IndexModel(PRN221_StudentManagementSystemContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Student Student { get; set; }

        [BindProperty]
        public Student RegisterStudent { get; set; }
        [BindProperty]
        public string? ConfirmPassword { get; set; }
        [BindProperty]
        public string? Message { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }
        
        public IActionResult OnPostRegister()
        {
            if (RegisterStudent.Password != ConfirmPassword)
            {
                Message = "Password and Confirm Password are not match.";
                return Page();
            }
            if (ModelState.IsValid)
            {
                _context.Students.Add(RegisterStudent);
                _context.SaveChanges();
                return Redirect("/Login/Index");
            }
            return Page();
        }
    }
}

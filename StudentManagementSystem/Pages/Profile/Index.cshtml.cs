using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Pages.Profile
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

        [TempData]
        public string SuccessMessage { get; set; } // TempData to store success message

        public async Task<IActionResult> OnGetAsync()
        {
            string studentId = HttpContext?.Session.GetString("StudentId");
            if (studentId == null)
            {
                return NotFound();
            }

            Student = await _context.Students.FirstOrDefaultAsync(m => m.StudentId == studentId);

            if (Student == null)
            {
                return NotFound();
            }

            // Check for success message and display it
            if (!string.IsNullOrEmpty(SuccessMessage))
            {
                ViewData["SuccessMessage"] = SuccessMessage;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                // Set success message
                SuccessMessage = "Profile updated successfully";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(Student.StudentId))
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

        private bool StudentExists(string id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }
    }
}

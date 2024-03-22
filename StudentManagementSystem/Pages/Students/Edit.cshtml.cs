using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly PRN221_StudentManagementSystemContext _context;

        public EditModel(PRN221_StudentManagementSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; }

        public SelectList ClassList { get; set; }
        public SelectList MajorList { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            ViewData["MajorId"] = new SelectList(_context.Majors, "MajorId", "MajorName");
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassClassName");

            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Students.FindAsync(id);

            if (Student == null)
            {
                return NotFound();
            }

            ClassList = new SelectList(_context.Classes, "ClassId", "ClassClassName");
            MajorList = new SelectList(_context.Majors, "MajorId", "MajorName");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            ViewData["MajorId"] = new SelectList(_context.Majors, "MajorId", "MajorName");
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassClassName");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var existingStudent = await _context.Students.FindAsync(Student.StudentId);
                if (existingStudent == null)
                {
                    return NotFound();
                }

                existingStudent.StudentName = Student.StudentName;
                existingStudent.StudentEmail = Student.StudentEmail;
                existingStudent.Password = Student.Password;
                existingStudent.Dob = Student.Dob;
                existingStudent.Phone = Student.Phone;
                existingStudent.Semester = Student.Semester;
                existingStudent.ClassId = Student.ClassId;
                existingStudent.MajorId = Student.MajorId;
                existingStudent.Gender = Student.Gender;
                existingStudent.IsActive = Student.IsActive;
                Student.RoleId = 3;

                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
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
        }

        private bool StudentExists(string id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }
    }
}
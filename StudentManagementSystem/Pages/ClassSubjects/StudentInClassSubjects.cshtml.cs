using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagementSystem.Pages.ClassSubjects
{
    public class StudentInClassModel : PageModel
    {
        private readonly PRN221_StudentManagementSystemContext _context;

        public StudentInClassModel(PRN221_StudentManagementSystemContext context)
        {
            _context = context;
            Students = new List<Student>(); // Khởi tạo Students thành một danh sách trống
        }

        public List<Student> Students { get; set; } // Danh sách sinh viên

        public async Task OnGetAsync(int? classId)
        {
            if (classId.HasValue)
            {
                Students = await _context.Students.Where(s => s.ClassId == classId).ToListAsync();
                ViewData["ClassId"] = classId;
            }
        }
    }
}

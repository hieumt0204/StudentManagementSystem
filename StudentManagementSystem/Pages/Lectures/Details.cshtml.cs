using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Pages.Lectures
{
    public class DetailsModel : PageModel
    {
        private readonly StudentManagementSystem.Models.PRN221_StudentManagementSystemContext _context;

        public DetailsModel(StudentManagementSystem.Models.PRN221_StudentManagementSystemContext context)
        {
            _context = context;
        }

      public Lecture Lecture { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Lectures == null)
            {
                return NotFound();
            }

            var lecture = await _context.Lectures.FirstOrDefaultAsync(m => m.LectureId == id);
            if (lecture == null)
            {
                return NotFound();
            }
            else 
            {
                Lecture = lecture;
            }
            return Page();
        }
    }
}

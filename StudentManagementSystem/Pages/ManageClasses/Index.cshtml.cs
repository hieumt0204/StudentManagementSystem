using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Pages.ManageClasses
{
    public class IndexModel : PageModel
    {
        private readonly StudentManagementSystem.Models.PRN221_StudentManagementSystemContext _context;

        public IndexModel(StudentManagementSystem.Models.PRN221_StudentManagementSystemContext context)
        {
            _context = context;
        }

        public IList<Class> Class { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var studentId = HttpContext?.Session.GetString("StudentId");
            if (_context.Classes != null)
            {
                if(studentId == null)
                {
                    Class = await _context.Classes.ToListAsync();
                }
                else
                {
                    Class = await _context.Classes.Where(x => x.Students.Any(s => s.StudentId == studentId)).ToListAsync();
                }
                
            }

        }

    
    }
}

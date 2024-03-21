using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly StudentManagementSystem.Models.PRN221_StudentManagementSystemContext _context;

        public IndexModel(StudentManagementSystem.Models.PRN221_StudentManagementSystemContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;
        [BindProperty(SupportsGet =true,Name = "ipp")]
        public int ItemsPerPage { get; set; } = 10;
        //public const int ITEMS_PER_PAGE = 10;
        [BindProperty(SupportsGet =true, Name = "p")]
        
        public int currentPage { get; set; }

        public int countPages { get; set; }
        [BindProperty]
        public int? RoleId { get; set; }
        [BindProperty]
        public string? MajorId { get; set; }
        [BindProperty]
        public string? StudentName { get; set; }

        public async Task OnGetAsync(string? majorId, string? studentName)
        {
            ViewData["MajorId"] = new SelectList(_context.Majors, "MajorId", "MajorName");
            IQueryable<Student> query = _context.Students
                                        .Include(s => s.Major)
                                        .Include(x => x.Class);
                                        
            MajorId = majorId;

            if (MajorId != null)
            {
                query = query.Where(s => s.MajorId == MajorId);
            }
           
            StudentName = studentName;
            if (!string.IsNullOrEmpty(StudentName))
            {
                query = query.Where(s => s.StudentName.Contains(StudentName));
            }

            int totalStudent = await query.CountAsync();

            countPages = (int)Math.Ceiling((double)totalStudent / ItemsPerPage);

            if (currentPage < 1)
            {
                currentPage = 1;
            }
            if (currentPage > countPages)
                currentPage = countPages;
            currentPage = Math.Max(currentPage, 1);
            Student = await query
                .OrderBy(s => s.Semester)
                .Skip((currentPage - 1) * ItemsPerPage)
                .Take(ItemsPerPage)
                .ToListAsync();

        }
    }
}

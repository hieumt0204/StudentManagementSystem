using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace StudentManagementSystem.Pages.Subjects
{

   
    public class IndexModel : PageModel
    {
        private readonly StudentManagementSystem.Models.PRN221_StudentManagementSystemContext _context;

        public IndexModel(StudentManagementSystem.Models.PRN221_StudentManagementSystemContext context)
        {
            _context = context;
        }

        public IList<Subject> Subject { get;set; } = default!;
        [BindProperty]
        public string? SubjectId { get; set; }
        [BindProperty(SupportsGet = true, Name = "ipp")]
        public int ItemsPerPage { get; set; } = 15;
        //public const int ITEMS_PER_PAGE = 10;
        [BindProperty(SupportsGet = true, Name = "p")]

        public int currentPage { get; set; }

        public int countPages { get; set; }
        public async Task OnGetAsync(string? subjectId)
        {
            if (_context.Subjects != null)
            {
                Subject = await _context.Subjects.ToListAsync();
            }
            SubjectId = subjectId;
            int totalSubjects = await _context.Subjects.CountAsync();
            ViewData["TotalSubjects"] = totalSubjects;

            countPages = (int)Math.Ceiling((double)totalSubjects / ItemsPerPage);

            if (currentPage < 1)
            {
                currentPage = 1;
            }
            if (currentPage > countPages)
                currentPage = countPages;
            currentPage = Math.Max(currentPage, 1);
            Subject = await _context.Subjects
                .Where(x => x.SubjectId.Contains(SubjectId) || SubjectId == null)
                .OrderBy(s => s.SubjectId)
                .Skip((currentPage - 1) * ItemsPerPage)
                .Take(ItemsPerPage)
                .ToListAsync();

            
        }
    }
}

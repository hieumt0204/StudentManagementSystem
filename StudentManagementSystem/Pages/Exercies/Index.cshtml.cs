using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Pages.Exercises
{
    public class IndexModel : PageModel
    {
        private readonly StudentManagementSystem.Models.PRN221_StudentManagementSystemContext _context;

        public IndexModel(StudentManagementSystem.Models.PRN221_StudentManagementSystemContext context)
        {
            _context = context;
        }
        public IQueryable<Excercy> query;
        public IList<Excercy> Excercy { get; set; } = default!;
        [BindProperty(SupportsGet = true, Name = "ipp")]
        public int ItemsPerPage { get; set; } = 15;
        //public const int ITEMS_PER_PAGE = 10;
        [BindProperty(SupportsGet = true, Name = "p")]

        public int currentPage { get; set; }

        public int countPages { get; set; }
        [BindProperty]
        public string? SubjectId { get; set; }

        public async Task OnGetAsync(string? subjectId)
        {
            query = _context.Excercies.Include(x => x.Subject);

            SubjectId = subjectId;
            if (!string.IsNullOrEmpty(SubjectId))
            {
                query = _context.Excercies.Include(e => e.Subject).Where(x => x.SubjectId.Contains(SubjectId));
            }
            
            
            int totalExcercies = await _context.Excercies.CountAsync();
            ViewData["TotalExcercies"] = totalExcercies;
            countPages = (int)Math.Ceiling((double)totalExcercies / ItemsPerPage);
            if (currentPage < 1)
            {
                currentPage = 1;
            }
            if (currentPage > countPages)
                currentPage = countPages;
            currentPage = Math.Max(currentPage, 1);
            Excercy = await query
               .OrderBy(s => s.SubjectId)
               .Skip((currentPage - 1) * ItemsPerPage)
               .Take(ItemsPerPage)
               .ToListAsync();

        }
    }
}
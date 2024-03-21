using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Pages.ClassSubjects
{
    public class IndexModel : PageModel
    {
        private readonly PRN221_StudentManagementSystemContext _context;

        public IndexModel(PRN221_StudentManagementSystemContext context)
        {
            _context = context;
        }

        public IList<ClassSubject> ClassSubject { get; set; } = new List<ClassSubject>();
        [BindProperty]
        public string? SubjectId { get; set; }
        [BindProperty]
        public int? ClassId { get; set; }
        [BindProperty(SupportsGet = true, Name = "ipp")]
        public int ItemsPerPage { get; set; } = 15;
        //public const int ITEMS_PER_PAGE = 10;
        [BindProperty(SupportsGet = true, Name = "p")]

        public int currentPage { get; set; }

        public int countPages { get; set; }


        public async Task OnGetAsync(string? subjectId, int? classId)
        {
            ViewData["SubjectId"] = new SelectList(await _context.Subjects.ToListAsync(), "SubjectId", "SubjectId");
            ViewData["ClassId"] = new SelectList(await _context.Classes.ToListAsync(), "ClassId", "ClassClassName");


            IQueryable<ClassSubject> query = _context.ClassSubjects
                .Include(c => c.Class)
                .Include(c => c.Lecture)
                .Include(c => c.RoomNavigation)
                .Include(c => c.Subject);
            if(!string.IsNullOrEmpty(subjectId))
            {
                SubjectId = subjectId;
                query = query.Where(x => x.SubjectId == SubjectId);
            }
            if(classId != null)
            {
                ClassId = classId;
                query = query.Where(x => x.ClassId == ClassId);
            }
            int totalClassSubject = await query.CountAsync();
            countPages = (int)Math.Ceiling((double)totalClassSubject / ItemsPerPage);
            if (currentPage < 1)
            {
                currentPage = 1;
            }
            if (currentPage > countPages)
                currentPage = countPages;
            currentPage = Math.Max(currentPage, 1);
            ClassSubject = await query
                .OrderBy(s => s.SubjectId)
                .Skip((currentPage - 1) * ItemsPerPage)
                .Take(ItemsPerPage)
                .ToListAsync();
            
        }

        public async Task OnPostAsync()
        {
            
        }

       
    }
}

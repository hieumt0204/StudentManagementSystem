using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Pages.ClassSubjects
{
    public class GetClassSubjectsModel : PageModel
    {
        private readonly PRN221_StudentManagementSystemContext _context;
        public GetClassSubjectsModel(PRN221_StudentManagementSystemContext context)
        {
            _context = context;
        }
        [BindProperty]
        public string SubjectId { get; set; }
        [BindProperty]
        public int ClassId { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            List<ClassSubject> classSubjects = await _context.ClassSubjects.ToListAsync();
            var classSubject = classSubjects.Where(cs => cs.SubjectId == SubjectId && cs.ClassId == ClassId).FirstOrDefault();

           
            return new JsonResult(classSubjects);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Pages.Home
{
    public class IndexModel : PageModel
    {
        public readonly ILogger<IndexModel> _logger;
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public string Message { get; set; }
        public int totalSubject { get; set; }
        private readonly PRN221_StudentManagementSystemContext _context = new PRN221_StudentManagementSystemContext();
        public void OnGet() {
            Message = TempData["Message"] as string;
            int totalStudent = _context.Students.Count();
            ViewData["totalStudent"] = totalStudent;
            totalSubject = _context.Subjects.Count();
            ViewData["totalSubject"] = totalSubject;
            var totalClaass = _context.Classes.Count();
            ViewData["totalClass"] = totalClaass;
            var totalLectures = _context.Lectures.Count();
            ViewData["totalLectures"] = totalLectures;
        }
    }
}

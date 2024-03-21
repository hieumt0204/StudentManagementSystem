using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;
using System.Security.Claims;

namespace StudentManagementSystem.Pages.Login
{
    public class IndexModel : PageModel
    {
        private readonly PRN221_StudentManagementSystemContext _context;
        public IndexModel(PRN221_StudentManagementSystemContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Student Student { get; set; }
        
        [BindProperty]
        public Student RegisterStudent { get; set; }
        [BindProperty]
        public string? ConfirmPassword { get; set; }
        [BindProperty]
        public string? Message { get; set; }
        public async Task<IActionResult> OnGetLoginAsync()
        {
           
            int? roleId = HttpContext.Session.GetInt32("RoleId");
            if (roleId != null)
            {
                if (roleId == (int)RoleEnum.ADMIN)
                {
                    return Redirect("Students");
                }
                else if (roleId == (int)RoleEnum.STUDENT)
                {
                    return Redirect("Subjects");
                }
                else if (roleId == (int)RoleEnum.TEACHER)
                {
                    return Redirect("Lectures");
                }
            }
                
                    return Page();
                
         }
        public async Task<IActionResult> OnPostLoginAsync()
        {
            if(string.IsNullOrEmpty(Student.StudentEmail) || string.IsNullOrEmpty(Student.Password))
            {
                Message = "Email anhd password are require.";
                return Page();
            }

            var student = await _context.Students.FirstOrDefaultAsync(m => m.StudentEmail.Equals(Student.StudentEmail));
            var lecture = await _context.Lectures.FirstOrDefaultAsync(m => m.LectureEmail.Equals(Student.StudentEmail));
            var admin = await _context.Admins.FirstOrDefaultAsync(m => m.Username.Equals(Student.StudentEmail));
            if ( Student.Password != null && admin != null && admin.Password.Equals(Student.Password))
            {
               if(admin.RoleId != null)
                {
                    //var clamims = new List<Claim>() { 
                    //                new Claim(ClaimTypes.Name, admin.AdminName),
                    //                new Claim(ClaimTypes.Role, "Admin")
                    //};
                    //var identity = new ClaimsIdentity(clamims, "Admin");

                    //var principal = new ClaimsPrincipal(identity);

                    //await HttpContext.SignInAsync("Admin", principal, new AuthenticationProperties()
                    //{
                    //    IsPersistent = true
                    //});
                    //var routeValues = new RouteValueDictionary
                    //{
                    //    {"area","Admin" },
                    //    {"claimType","AdminClaim" },
                    //    {"claimValue","true" }
                    //};
                


                    HttpContext.Session.SetInt32("RoleId", (int)admin.RoleId);

                    Message = "Login succesfully. Welcome admin!";
                    TempData["Message"] = "Đăng nhập thành công";
                    return Redirect("Home");
                }
            }
            else if (student != null && Student.Password != null && student.Password == Student.Password)
            {
                HttpContext.Session.SetString("StudentId", student.StudentId);
                if (student.RoleId != null)
                {
                    HttpContext.Session.SetInt32("RoleId", (int)student.RoleId);
                    return Redirect("Home");
                }
            }
            else if(lecture != null && Student.Password != null && lecture.Password == Student.Password)
            {
                HttpContext.Session.SetString("LectureId", lecture.LectureId);
                if (lecture.RoleId != null)
                {
                    HttpContext.Session.SetInt32("RoleId", (int)lecture.RoleId);
                    return Redirect("Home");
                }
            }
            //else if (student.isActive == false && student != null)
            //{
            //    Message = "Your Account is InActive!";
            //}
            else
            {
                Message = "Email or Password is incorrect";

            }
         
          
           

            return Page();

        }
       //register
       public async Task<IActionResult> OnPostRegisterAsync()
        {
            if (RegisterStudent.Password != ConfirmPassword)
            {
                Message = "Password and Confirm Password are not match";
                return Page();
            }
            if (RegisterStudent.Password == null || RegisterStudent.StudentEmail == null || RegisterStudent.StudentName == null)
            {
                Message = "Email, Name and Password are require";
                return Page();
            }
            var student = await _context.Students.FirstOrDefaultAsync(m => m.StudentEmail.Equals(RegisterStudent.StudentEmail));
            if (student != null)
            {
                Message = "Email is already exist";
                return Page();
            }
            RegisterStudent.RoleId = (int)RoleEnum.STUDENT;
            _context.Students.Add(RegisterStudent);
            await _context.SaveChangesAsync();
            return Redirect("Index");
        }

        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("StudentId");
            HttpContext.Session.Remove("LectureId");
            HttpContext.Session.Remove("RoleId");
            return Redirect("/Home/Index");
        }


    }
}

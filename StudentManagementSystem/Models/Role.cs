namespace StudentManagementSystem.Models
{
    public partial class Role 
    {
        public Role()
        {
            Admins = new HashSet<Admin>();
            Lectures = new HashSet<Lecture>();
            Students = new HashSet<Student>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;

        public virtual ICollection<Admin> Admins { get; set; }
        public virtual ICollection<Lecture> Lectures { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
        public enum RoleEnum
        {
            ADMIN = 1,
            TEACHER = 2,
            STUDENT = 3
        }
 }


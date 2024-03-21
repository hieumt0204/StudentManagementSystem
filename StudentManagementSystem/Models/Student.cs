using System;
using System.Collections.Generic;

namespace StudentManagementSystem.Models
{
    public partial class Student
    {
        public Student()
        {
            StudentsExcercies = new HashSet<StudentsExcercy>();
            ExamSchedules = new HashSet<ExamSchedule>();
        }

        public string StudentId { get; set; } = null!;
        public string StudentName { get; set; } = null!;
        public string StudentEmail { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime? Dob { get; set; }
        public string? Phone { get; set; }
        public int Semester { get; set; }
        public int RoleId { get; set; }
        public string MajorId { get; set; } = null!;
        public bool? Gender { get; set; }
        public bool? IsActive { get; set; }
        public int? ClassId { get; set; }

        public virtual Class? Class { get; set; }
        public virtual Major Major { get; set; } = null!;
        public virtual ICollection<StudentsExcercy> StudentsExcercies { get; set; }

        public virtual ICollection<ExamSchedule> ExamSchedules { get; set; }
    }
}

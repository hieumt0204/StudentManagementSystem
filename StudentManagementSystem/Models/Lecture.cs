using System;
using System.Collections.Generic;

namespace StudentManagementSystem.Models
{
    public partial class Lecture
    {
        public Lecture()
        {
            ClassSubjects = new HashSet<ClassSubject>();
            ExamSchedules = new HashSet<ExamSchedule>();
        }

        public string LectureId { get; set; } = null!;
        public string LectureName { get; set; } = null!;
        public string LectureEmail { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime? Dob { get; set; }
        public string? Phone { get; set; }
        public int RoleId { get; set; }

        public virtual ICollection<ClassSubject> ClassSubjects { get; set; }
        public virtual ICollection<ExamSchedule> ExamSchedules { get; set; }
    }
}

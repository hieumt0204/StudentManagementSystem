using System;
using System.Collections.Generic;

namespace StudentManagementSystem.Models
{
    public partial class ExamSchedule
    {
        public ExamSchedule()
        {
            Students = new HashSet<Student>();
        }

        public int ExamScheduleId { get; set; }
        public string Room { get; set; } = null!;
        public string TypeOfExam { get; set; } = null!;
        public DateTime Date { get; set; }
        public string TimeFrom { get; set; } = null!;
        public string TimeTo { get; set; } = null!;
        public DateTime DateOfPublic { get; set; }
        public DateTime? DateOfResit { get; set; }
        public string? TimeFromResit { get; set; }
        public string? TimeToResit { get; set; }
        public DateTime? DateOfPublicResit { get; set; }
        public string LectureId { get; set; } = null!;
        public string SubjectId { get; set; } = null!;
        public int? SemesterId { get; set; }

        public virtual Lecture Lecture { get; set; } = null!;
        public virtual Semester? Semester { get; set; }
        public virtual Subject Subject { get; set; } = null!;

        public virtual ICollection<Student> Students { get; set; }
    }
}

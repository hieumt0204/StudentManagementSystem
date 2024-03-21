using System;
using System.Collections.Generic;

namespace StudentManagementSystem.Models
{
    public partial class ClassSubject
    {
        public string ClassSubjectId { get; set; } = null!;
        public int Slot { get; set; }
        public DateTime Date { get; set; }
        public string Room { get; set; } = null!;
        public string LectureId { get; set; } = null!;
        public string SubjectId { get; set; } = null!;
        public int NumberOfStudents { get; set; }
        public int? ClassId { get; set; }

        public virtual Class? Class { get; set; }
        public virtual Lecture Lecture { get; set; } = null!;
        public virtual Room RoomNavigation { get; set; } = null!;
        public virtual Subject Subject { get; set; } = null!;
    }
}

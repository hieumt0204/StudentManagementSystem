using System;
using System.Collections.Generic;

namespace StudentManagementSystem.Models
{
    public partial class Subject
    {
        public Subject()
        {
            ClassSubjects = new HashSet<ClassSubject>();
            ExamSchedules = new HashSet<ExamSchedule>();
            Excercies = new HashSet<Excercy>();
        }

        public string SubjectId { get; set; } = null!;
        public string SubjectName { get; set; } = null!;
        public int Credit { get; set; }

        public virtual ICollection<ClassSubject> ClassSubjects { get; set; }
        public virtual ICollection<ExamSchedule> ExamSchedules { get; set; }
        public virtual ICollection<Excercy> Excercies { get; set; }
    }
}

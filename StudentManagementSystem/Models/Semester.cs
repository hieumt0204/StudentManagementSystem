using System;
using System.Collections.Generic;

namespace StudentManagementSystem.Models
{
    public partial class Semester
    {
        public Semester()
        {
            ExamSchedules = new HashSet<ExamSchedule>();
        }

        public int SemesterId { get; set; }
        public string? ClassSemesterName { get; set; }
        public int Year { get; set; }

        public virtual ICollection<ExamSchedule> ExamSchedules { get; set; }
    }
}

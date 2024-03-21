using System;
using System.Collections.Generic;

namespace StudentManagementSystem.Models
{
    public partial class StudentTimeTableIdStudent
    {
        public int TimetableId { get; set; }
        public string StudentId { get; set; } = null!;
        public string? Attendence { get; set; }

        public virtual Student Student { get; set; } = null!;
        public virtual StudentTimeTableId Timetable { get; set; } = null!;
    }
}

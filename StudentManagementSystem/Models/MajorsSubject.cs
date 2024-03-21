using System;
using System.Collections.Generic;

namespace StudentManagementSystem.Models
{
    public partial class MajorsSubject
    {
        public string MajorId { get; set; } = null!;
        public string SubjectId { get; set; } = null!;
        public int Semester { get; set; }

        public virtual Major Major { get; set; } = null!;
        public virtual Subject Subject { get; set; } = null!;
    }
}

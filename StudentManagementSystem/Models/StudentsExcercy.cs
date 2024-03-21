using System;
using System.Collections.Generic;

namespace StudentManagementSystem.Models
{
    public partial class StudentsExcercy
    {
        public string StudentId { get; set; } = null!;
        public string ExerciseName { get; set; } = null!;
        public float? Mark { get; set; }

        public virtual Excercy ExerciseNameNavigation { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
    }
}

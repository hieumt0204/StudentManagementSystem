using System;
using System.Collections.Generic;

namespace StudentManagementSystem.Models
{
    public partial class Excercy
    {
        public Excercy()
        {
            StudentsExcercies = new HashSet<StudentsExcercy>();
        }

        public string ExerciseName { get; set; } = null!;
        public float Percentage { get; set; }
        public DateTime Dateline { get; set; }
        public string SubjectId { get; set; } = null!;

        public virtual Subject Subject { get; set; } = null!;
        public virtual ICollection<StudentsExcercy> StudentsExcercies { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace StudentManagementSystem.Models
{
    public partial class Class
    {
        public Class()
        {
            ClassSubjects = new HashSet<ClassSubject>();
            Students = new HashSet<Student>();
        }

        public int ClassId { get; set; }
        public string? ClassClassName { get; set; }

        public virtual ICollection<ClassSubject> ClassSubjects { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}

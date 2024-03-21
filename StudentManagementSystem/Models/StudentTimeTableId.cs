using System;
using System.Collections.Generic;

namespace StudentManagementSystem.Models
{
    public partial class StudentTimeTableId
    {
        public StudentTimeTableId()
        {
            ClassSubjects = new HashSet<ClassSubject>();
            StudentTimeTableIdStudents = new HashSet<StudentTimeTableIdStudent>();
        }

        public int Id { get; set; }

        public virtual ICollection<ClassSubject> ClassSubjects { get; set; }
        public virtual ICollection<StudentTimeTableIdStudent> StudentTimeTableIdStudents { get; set; }
    }
}

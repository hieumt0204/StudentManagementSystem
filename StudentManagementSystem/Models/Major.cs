using System;
using System.Collections.Generic;

namespace StudentManagementSystem.Models
{
    public partial class Major
    {
        public Major()
        {
            Students = new HashSet<Student>();
        }

        public string MajorId { get; set; } = null!;
        public string MajorName { get; set; } = null!;

        public virtual ICollection<Student> Students { get; set; }
    }
}

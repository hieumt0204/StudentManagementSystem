using System;
using System.Collections.Generic;

namespace StudentManagementSystem.Models
{
    public partial class Room
    {
        public Room()
        {
            ClassSubjects = new HashSet<ClassSubject>();
        }

        public string RoomId { get; set; } = null!;

        public virtual ICollection<ClassSubject> ClassSubjects { get; set; }
    }
}

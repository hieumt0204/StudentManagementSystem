using System;
using System.Collections.Generic;

namespace StudentManagementSystem.Models
{
    public partial class Admin
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string AdminName { get; set; } = null!;
        public string? Phone { get; set; }
        public int RoleId { get; set; }
    }
}

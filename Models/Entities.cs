using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace CollegeManagementSystem.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public int GroupId { get; set; }
    }

    public class Teacher
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
    }

    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}


namespace CollegeManagementSystem.Models {
    public class Person {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Role { get; set; }
    }

    public class Student : Person {
        public int GroupId { get; set; }
    }

    public class Teacher : Person {
    }

    public class Group {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Course {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
    }

    public class ScheduleEntry {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int CourseId { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
    }

    public class Mark {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int Value { get; set; }
    }
}

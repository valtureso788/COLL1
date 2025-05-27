using System;
using System.Collections.Generic;

namespace CollegeManagementSystem.Services
{
    public class StudentService
    {
        private List<Student> students = new List<Student>();
        private int nextId = 1;

        public void RegisterStudent(string name, DateTime birthDate, int groupId)
        {
            students.Add(new Student
            {
                Id = nextId++,
                Name = name,
                BirthDate = birthDate,
                GroupId = groupId
            });
            Console.WriteLine($"Student {name} registered.");
        }

        public void PrintAllStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            Console.WriteLine("=== Students List ===");
            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Birth Date: {student.BirthDate.ToShortDateString()}, Group ID: {student.GroupId}");
            }
        }

        public void DeleteStudent(int id)
        {
            var student = students.Find(s => s.Id == id);
            if (student != null)
            {
                students.Remove(student);
                Console.WriteLine($"Student with ID {id} deleted.");
            }
            else
            {
                Console.WriteLine($"Student with ID {id} not found.");
            }
        }

        private class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime BirthDate { get; set; }
            public int GroupId { get; set; }
        }
    }
}
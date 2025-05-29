using System;
using System.Data;
using CollegeManagementSystem.Data;
using CollegeManagementSystem.Models;

namespace CollegeManagementSystem.Business.Services
{
    public class TeacherService
    {
        private readonly DatabaseManager _dbManager;

        public TeacherService(DatabaseManager dbManager)
        {
            _dbManager = dbManager ?? throw new ArgumentNullException(nameof(dbManager));
        }

        public void PrintAllTeachers()
        {
            var dt = _dbManager.ExecuteQuery("SELECT t.PersonId as Id, p.Name as FullName, c.Name as Subject FROM Teachers t JOIN Persons p ON t.PersonId = p.Id LEFT JOIN Courses c ON c.TeacherId = t.PersonId");

            Console.WriteLine("Преподаватели:");
            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("Преподаватели не найдены.");
                return;
            }

            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine($"ID: {row["Id"]}, ФИО: {row["FullName"]}, Предмет: {row["Subject"] ?? "Не назначен"}");
            }
        }
    }
}

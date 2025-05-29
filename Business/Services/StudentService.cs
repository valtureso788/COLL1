using System;
using System.Data;
using CollegeManagementSystem.Data;
using CollegeManagementSystem.Models;

namespace CollegeManagementSystem.Business.Services
{
    public class StudentService
    {
        private readonly DatabaseManager _dbManager;

        public StudentService(DatabaseManager dbManager)
        {
            _dbManager = dbManager ?? throw new ArgumentNullException(nameof(dbManager));
        }

        public void PrintAllStudents()
        {
            var dt = _dbManager.ExecuteQuery("SELECT s.PersonId as Id, p.Name as FullName, p.BirthDate, s.GroupId FROM Students s JOIN Persons p ON s.PersonId = p.Id");

            Console.WriteLine("Студенты:");
            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("Студенты не найдены.");
                return;
            }

            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine($"ID: {row["Id"]}, ФИО: {row["FullName"]}, Дата рождения: {row["BirthDate"]}, Группа ID: {row["GroupId"]}");
            }
        }
    }
}

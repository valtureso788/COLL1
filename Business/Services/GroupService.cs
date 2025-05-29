using System;
using System.Data;
using CollegeManagementSystem.Data;
using CollegeManagementSystem.Models;

namespace CollegeManagementSystem.Business.Services
{
    public class GroupService
    {
        private readonly DatabaseManager _dbManager;

        public GroupService(DatabaseManager dbManager)
        {
            _dbManager = dbManager ?? throw new ArgumentNullException(nameof(dbManager));
        }

        public void PrintAllGroups()
        {
            var dt = _dbManager.ExecuteQuery("SELECT * FROM Groups");

            Console.WriteLine("Группы:");
            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("Группы не найдены.");
                return;
            }

            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine($"ID: {row["Id"]}, Название: {row["Name"]}");
            }
        }
    }
}

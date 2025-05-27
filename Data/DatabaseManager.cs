
using System;
using System.Data.SQLite;

namespace CollegeManagementSystem.Data {
    public class DatabaseManager {
        private SQLiteConnection connection;

        public DatabaseManager(string connectionString) {
            connection = new SQLiteConnection(connectionString);
            connection.Open();
        }

        public void AddStudent(string name, DateTime birthDate, int groupId) {
            var cmd = new SQLiteCommand("INSERT INTO Persons (Name, BirthDate, Role) VALUES (@name, @birthDate, 'Student')", connection);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@birthDate", birthDate.ToString("yyyy-MM-dd"));
            cmd.ExecuteNonQuery();

            long personId = connection.LastInsertRowId;
            cmd = new SQLiteCommand("INSERT INTO Students (PersonId, GroupId) VALUES (@id, @groupId)", connection);
            cmd.Parameters.AddWithValue("@id", personId);
            cmd.Parameters.AddWithValue("@groupId", groupId);
            cmd.ExecuteNonQuery();
        }

        // Аналогично добавляются другие методы (GetStudents, AddCourse и т.д.)
    }
}

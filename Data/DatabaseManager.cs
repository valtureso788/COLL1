using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace CollegeManagementSystem.Data
{
    public class DatabaseManager
    {
        private readonly string _connectionString;
        private SQLiteConnection _connection;

        public DatabaseManager(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            _connection = new SQLiteConnection(_connectionString);
        }

        private void EnsureConnectionOpen()
        {
            if (_connection.State != ConnectionState.Open)
                _connection.Open();
        }

        public int ExecuteNonQuery(string query, Dictionary<string, object>? parameters = null)
        {
            EnsureConnectionOpen();
            using var command = new SQLiteCommand(query, _connection);
            AddParameters(command, parameters);
            return command.ExecuteNonQuery();
        }

        public object? ExecuteScalar(string query, Dictionary<string, object>? parameters = null)
        {
            EnsureConnectionOpen();
            using var command = new SQLiteCommand(query, _connection);
            AddParameters(command, parameters);
            return command.ExecuteScalar();
        }

        public DataTable ExecuteQuery(string query, Dictionary<string, object>? parameters = null)
        {
            EnsureConnectionOpen();
            using var command = new SQLiteCommand(query, _connection);
            AddParameters(command, parameters);
            using var adapter = new SQLiteDataAdapter(command);
            var table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        private void AddParameters(SQLiteCommand command, Dictionary<string, object>? parameters)
        {
            if (parameters == null) return;

            foreach (var param in parameters)
                command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
        }

        public bool TestConnection()
        {
            try
            {
                EnsureConnectionOpen();
                return _connection.State == ConnectionState.Open;
            }
            catch
            {
                return false;
            }
        }
    }
}

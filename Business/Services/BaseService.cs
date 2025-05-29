using System.Data.SQLite;

namespace CollegeManagementSystem.Business.Services
{
    public abstract class BaseService
    {
        protected readonly SQLiteConnection connection;

        protected BaseService(SQLiteConnection connection)
        {
            this.connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        protected SQLiteCommand CreateCommand(string query)
        {
            var command = connection.CreateCommand();
            command.CommandText = query;
            return command;
        }

        protected void EnsureConnectionOpen()
        {
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();
        }

        protected void EnsureConnectionClosed()
        {
            if (connection.State != System.Data.ConnectionState.Closed)
                connection.Close();
        }
    }
}
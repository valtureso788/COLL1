using System;
using CollegeManagementSystem.Business.Services;
using CollegeManagementSystem.Data;
using System.IO;

class Program
{
    static void Main()
    {
        // Создаем базу данных SQLite и инициализируем схему
        string dbPath = "college.db";
        string connectionString = $"Data Source={dbPath};Version=3;";
        
        // Проверяем, существует ли файл базы данных
        bool dbExists = File.Exists(dbPath);
        
        var dbManager = new DatabaseManager(connectionString);
        
        // Если база данных не существует, создаем её и инициализируем схему
        if (!dbExists)
        {
            InitializeDatabase(dbManager);
            Console.WriteLine("База данных создана и инициализирована.");
        }

        var studentService = new StudentService(dbManager);
        var teacherService = new TeacherService(dbManager);
        var groupService = new GroupService(dbManager);

        Console.WriteLine("Тест соединения с БД: " + (dbManager.TestConnection() ? "Успешно" : "Ошибка"));
        Console.WriteLine();

        groupService.PrintAllGroups();
        Console.WriteLine();
        
        studentService.PrintAllStudents();
        Console.WriteLine();
        
        teacherService.PrintAllTeachers();
    }
    
    static void InitializeDatabase(DatabaseManager dbManager)
    {
        // Создаем таблицы согласно схеме
        string schemaScript = File.ReadAllText("schema.sql");
        
        // Разделяем скрипт на отдельные команды
        string[] commands = schemaScript.Split(';');
        
        foreach (string command in commands)
        {
            if (!string.IsNullOrWhiteSpace(command))
            {
                dbManager.ExecuteNonQuery(command);
            }
        }
        
        // Добавляем тестовые данные
        InsertTestData(dbManager);
    }
    
    static void InsertTestData(DatabaseManager dbManager)
    {
        // Добавляем группы
        dbManager.ExecuteNonQuery("INSERT INTO Groups (Id, Name) VALUES (1, 'ИС-31')");
        dbManager.ExecuteNonQuery("INSERT INTO Groups (Id, Name) VALUES (2, 'ПО-42')");
        
        // Добавляем персоны (для студентов и преподавателей)
        dbManager.ExecuteNonQuery("INSERT INTO Persons (Id, Name, BirthDate, Role) VALUES (1, 'Иванов Иван', '2000-01-15', 'Student')");
        dbManager.ExecuteNonQuery("INSERT INTO Persons (Id, Name, BirthDate, Role) VALUES (2, 'Петров Петр', '1999-05-20', 'Student')");
        dbManager.ExecuteNonQuery("INSERT INTO Persons (Id, Name, BirthDate, Role) VALUES (3, 'Сидорова Анна', '1980-03-10', 'Teacher')");
        
        // Добавляем студентов
        dbManager.ExecuteNonQuery("INSERT INTO Students (PersonId, GroupId) VALUES (1, 1)");
        dbManager.ExecuteNonQuery("INSERT INTO Students (PersonId, GroupId) VALUES (2, 2)");
        
        // Добавляем преподавателей
        dbManager.ExecuteNonQuery("INSERT INTO Teachers (PersonId) VALUES (3)");
        
        // Добавляем курсы
        dbManager.ExecuteNonQuery("INSERT INTO Courses (Id, Name, TeacherId) VALUES (1, 'Программирование', 3)");
    }
}

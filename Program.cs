using System;
using CollegeManagementSystem.Services;

namespace CollegeManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentService studentService = new StudentService();
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== College Management System ===");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View All Students");
                Console.WriteLine("3. Delete Student");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddStudent(studentService);
                        break;
                    case "2":
                        studentService.PrintAllStudents();
                        Pause();
                        break;
                    case "3":
                        DeleteStudent(studentService);
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        Pause();
                        break;
                }
            }

            Console.WriteLine("Exiting the system. Goodbye!");
        }

        static void AddStudent(StudentService service)
        {
            try
            {
                Console.Write("Enter name: ");
                string name = Console.ReadLine();

                Console.Write("Enter birth date (yyyy-MM-dd): ");
                string dateInput = Console.ReadLine();
                DateTime birthDate = DateTime.ParseExact(dateInput, "yyyy-MM-dd", null);

                Console.Write("Enter group id: ");
                int groupId = int.Parse(Console.ReadLine());

                service.RegisterStudent(name, birthDate, groupId);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please try again.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            Pause();
        }

        static void DeleteStudent(StudentService service)
        {
            try
            {
                Console.Write("Enter student ID to delete: ");
                int id = int.Parse(Console.ReadLine());
                service.DeleteStudent(id);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. ID must be a number.");
            }
            Pause();
        }

        static void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
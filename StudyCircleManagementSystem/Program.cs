using StudyCircleManagementSystem.BusinessLayer;
using StudyCircleManagementSystem.Entities;
using System;

namespace StudyCircleManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                GetLoginDetails();
            }
            catch (Exception exception)
            {
                Console.Clear();
                Console.WriteLine("Invalid Input.\n{0}\nPress any key to exit.", exception.Message);
            }
            Console.ReadKey();
        }

        public static void GetLoginDetails()
        {
            Console.Clear();

            char smileClear = '\u263a';
            Console.Write(smileClear);

            Console.WriteLine("Press\n\n1.Login\n2.Exit\n");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    VerifyUsername();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

        public static void VerifyUsername()
        {
            Console.Clear();
            Console.WriteLine("UserName: ");
            string inputUsername = Console.ReadLine();

            Console.WriteLine("Password: ");
            //string inputPassword = Console.ReadLine();

            string inputPassword = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);
                //
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    inputPassword += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    Console.Write("\b");
                }
            }
            while (key.Key != ConsoleKey.Enter);

            //Console.WriteLine(inputPassword);
            //Console.ReadKey();

            LoginManager information = new LoginManager();
            StudyCircleManagementSystem.Web.Models.LoginDetail details = information.GetDetails(inputUsername);

            if (details.UserName == inputUsername && details.Password == inputPassword)
            {
                Console.Clear();
                Console.WriteLine("Hello {0},\n\t you are logged in as {1}.\n\nPress any key to enter.", details.UserName, details.Designation);
                Console.ReadKey();
                switch (details.Designation)
                {
                    case "Manager":
                        Manager();
                        break;
                    case "faculty":
                        Faculty();
                        break;
                    case "student":
                        Student();
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please enter valid username and password.\nOnly two chances left.\nPress \n\n1.Login again\n2.Exit.");
                char choice = Convert.ToChar(Console.ReadLine());
                switch (choice)
                {
                    case '1':
                        VerifyUsername();
                        break;
                    case '2':
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }

            }
            Console.ReadKey();
        }

        public static void Manager()
        {
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("Press\n1.Courses details.\n2.Faculty details.\n3.Student details.\n\n4.Logout");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        CourseManagement courseManagement = new CourseManagement();
                        courseManagement.GetChoice();
                        break;
                    case 2:
                        FacultyManagement facultyManagement = new FacultyManagement();
                        facultyManagement.GetChoice();
                        break;
                    case 3:
                        StudentManagement studentManagement = new StudentManagement();
                        studentManagement.GetChoice();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Logged out successfully.\nPress any key to login again.");
                        Console.ReadKey();
                        GetLoginDetails();
                        break;
                    default:
                        break;
                }
            }
            while (choice < 5);
        }

        public static void Faculty()
        {
            FacultyManager functionWithFaculty = new FacultyManager();
            CourseManager functionWithCourse = new CourseManager();
            StudentManager functionWithStudent = new StudentManager();
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("Press \n1.View list of faculties.\n2.View list of courses.\n3.View list of students.\n\n4.Logout");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        FacultyManagement faculty = new FacultyManagement();
                        faculty.DisplayTheListOfFaculties(functionWithFaculty);
                        break;
                    case 2:
                        CourseManagement course = new CourseManagement();
                        course.DisplayTheListOfCourses(functionWithCourse);
                        break;
                    case 3:
                        StudentManagement student = new StudentManagement();
                        student.DisplayTheListOfStudents(functionWithStudent);
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Logged out successfully.\nPress any key to login again.");
                        Console.ReadKey();
                        GetLoginDetails();
                        break;

                    default:
                        break;
                }
            }
            while (choice < 5);
        }

        public static void Student()
        {
            Console.Clear();
            CourseManager functionWithCourse = new CourseManager();
            StudentManager functionWithStudent = new StudentManager();
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("Press \n1.View list of courses.\n2.View list of students.\n\n3.Logout");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {

                    case 1:
                        CourseManagement course = new CourseManagement();
                        course.DisplayTheListOfCourses(functionWithCourse);
                        break;
                    case 2:
                        StudentManagement student = new StudentManagement();
                        student.DisplayTheListOfStudents(functionWithStudent);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Logged out successfully.\nPress any key to login again.");
                        Console.ReadKey();
                        GetLoginDetails();
                        break;
                    default:
                        break;
                }
            }
            while (choice < 4);
        }
    }
}

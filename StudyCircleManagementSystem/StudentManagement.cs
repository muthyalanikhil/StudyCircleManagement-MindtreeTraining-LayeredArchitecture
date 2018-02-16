using StudyCircleManagementSystem.BusinessLayer;
using StudyCircleManagementSystem.Entities;
using System;
namespace StudyCircleManagementSystem
{
    class StudentManagement
    {
        public void GetChoice()
        {
            int choice;
            do
            {
                Console.Clear();
                StudentManager studentManager = new StudentManager();
                Console.WriteLine("----------Student---------\n\n");
                Console.WriteLine("1.View The List Of Students");
                Console.WriteLine("2.Insert New Student");
                Console.WriteLine("3.Delete Student");
                Console.WriteLine("4.Exit Student");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        DisplayTheListOfStudents(studentManager);
                        break;
                    case 2:
                        InsertNewStudent(studentManager);
                        DisplayTheListOfStudents(studentManager);
                        break;
                    case 3:
                        DisplayTheListOfStudents(studentManager);
                        DeleteStudent(studentManager);
                        break;

                }
            } while (choice < 4);
        }

        public void DeleteStudent(StudentManager studentManager)
        {
            DisplayTheListOfStudents(studentManager);

            Console.WriteLine();
            Console.WriteLine("Delete the student list");

            Student student = new Student();
            Console.WriteLine("Enter the student name to be deleted");
            student.Name = Console.ReadLine();

            studentManager.DeleteStudent(student);

            Console.WriteLine("Student Deleted successfully\n");
            Console.ReadKey();

            Console.Clear();
        }

        public void InsertNewStudent(StudentManager studentManager)
        {
            Student student = new Student();
            Console.WriteLine("insert into the student table");

            Console.WriteLine("Enter the student name");
            student.Name = Console.ReadLine();
            Console.WriteLine("Enter the course Name in which enrolled");
            student.CourseName = Console.ReadLine();
            Console.WriteLine("Enter the student phone Number");
            student.PhoneNumber = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter the student test Marks");
            student.TestMarks = Convert.ToInt32(Console.ReadLine());


            studentManager.InsertStudent(student);

            Console.WriteLine("Students details added successfully.\n");
            Console.ReadKey();

            Console.Clear();
        }

        public void DisplayTheListOfStudents(StudentManager studentmanager)
        {
            var studentDetails = studentmanager.GetStudentDetail();

            foreach (var studentDetail in studentDetails)
            {
                Console.WriteLine("The student Id is:{0}", studentDetail.Id);
                Console.WriteLine("The student name is:{0}", studentDetail.Name);
                Console.WriteLine("The course enrolled is:{0}", studentDetail.CourseName);
                Console.WriteLine("The student phone number is:{0}", studentDetail.PhoneNumber);
                Console.WriteLine("The student test marks is:{0}\n", studentDetail.TestMarks);
            }

            Console.ReadKey();
            Console.Clear();
        }
    }
}

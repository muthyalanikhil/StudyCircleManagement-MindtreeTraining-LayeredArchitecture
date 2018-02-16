using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyCircleManagementSystem.BusinessLayer;
using StudyCircleManagementSystem.Entities;

namespace StudyCircleManagementSystem
{
    class StudentManagement
    {
        public void GetChoice()
        {
            int choice;
            do
            {
                FunctionWithStudents functionWithStudent = new FunctionWithStudents();
                Console.WriteLine("----------Student---------");
                Console.WriteLine("1.View The List Of Students");
                Console.WriteLine("2.Insert New Student");
                Console.WriteLine("3.Delete Student");
                Console.WriteLine("4.Exit Student");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        DisplayTheListOfStudents(functionWithStudent);
                        break;
                    case 2:
                        InsertNewStudent(functionWithStudent);
                        DisplayTheListOfStudents(functionWithStudent);
                        break;
                    case 3:
                        DisplayTheListOfStudents(functionWithStudent);
                        DeleteStudent(functionWithStudent);
                        break;

                }
            } while (choice < 4);
        }

        private static void DeleteStudent(FunctionWithStudents functionWithStudent)
        {
            DisplayTheListOfStudents(functionWithStudent);

            Console.WriteLine();
            Console.WriteLine("Delete the student list");

            Console.WriteLine("Enter the student name to be deleted");
            string studentName = Console.ReadLine();

            functionWithStudent.DeleteStudent(studentName);

            Console.WriteLine("Student Deleted");
            Console.ReadKey();

            Console.Clear();
        }

        private static void InsertNewStudent(FunctionWithStudents functionWithStudent)
        {
            Console.WriteLine("insert into the student table");

            Console.WriteLine("Enter the student name");
            string studentNames = Console.ReadLine();
            Console.WriteLine("Enter the course Name in which enrolled");
            string courseNames = Console.ReadLine();
            Console.WriteLine("Enter the student phone Number");
            long studentPhoneNumbers = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter the student test Marks");
           int testMarks = Convert.ToInt32(Console.ReadLine());


            functionWithStudent.InsertStudent(studentNames,courseNames,studentPhoneNumbers,testMarks);

            Console.WriteLine("Entered the student detail");
            Console.ReadKey();

            Console.Clear();
        }

        private static void DisplayTheListOfStudents(FunctionWithStudents functionWithStudent)
        {
            var studentDetails = functionWithStudent.GetStudentDetail();

            foreach (var studentDetail in studentDetails)
            {
                Console.WriteLine("The student Id is:{0}", studentDetail.studentId);
                Console.WriteLine("The student name is:{0}", studentDetail.studentName);
                Console.WriteLine("The course enrolled is:{0}", studentDetail.courseName);
                Console.WriteLine("The student phone number is:{0}", studentDetail.studentPhoneNumber);
                Console.WriteLine("The student test marks is:{0}", studentDetail.testMarks);

           
            }
            Console.ReadKey();

            Console.Clear();
        }
    
    }

}

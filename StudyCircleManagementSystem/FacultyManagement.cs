using StudyCircleManagementSystem.BusinessLayer;
using StudyCircleManagementSystem.Entities;
using System;

namespace StudyCircleManagementSystem
{
    class FacultyManagement
    {
        public void GetChoice()
        {
            int choice;
            do
            {
                Console.Clear();
                FacultyManager facultyManager = new FacultyManager();
                Console.WriteLine("-------Faculty--------");
                Console.WriteLine("1.View The List Of Faculties");
                Console.WriteLine("2.Insert New Faculty");
                Console.WriteLine("3.Delete Faculty");
                Console.WriteLine("4.Update Faculty");
                Console.WriteLine("5.Exit faculty");
                choice = Convert.ToInt16(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        DisplayTheListOfFaculties(facultyManager);
                        break;
                    case 2:
                        InsertNewFaculty(facultyManager);
                        DisplayTheListOfFaculties(facultyManager);
                        break;
                    case 3:
                        DisplayTheListOfFaculties(facultyManager);
                        DeleteFaculties(facultyManager);
                        break;
                    case 4:
                        DisplayTheListOfFaculties(facultyManager);
                        UpdateFaculties(facultyManager);
                        break;                   
                        
                }
            }
            while (choice < 5);
        }

        public  void DeleteFaculties(FacultyManager facultyManager)
        {
            DisplayTheListOfFaculties(facultyManager);

            Console.WriteLine();
            Console.WriteLine("Delete from the faculty list");
            Faculty faculty = new Faculty();

            Console.WriteLine("Enter the faculty name to be deleted");
            faculty.Name = Console.ReadLine();
            

            facultyManager.DeleteFaculty(faculty);

            Console.WriteLine("Faculty Deleted successfully");
            Console.WriteLine("\n\n\nPress any key");
            Console.ReadKey();

            Console.Clear();
        }

        public  void InsertNewFaculty(FacultyManager facultyManager)
        {
            Console.WriteLine("insert into the faculty table");
            Faculty faculty = new Faculty();

            Console.WriteLine("Enter the faculty name");
            faculty.Name = Console.ReadLine();
            string designation = "faculty";
            facultyManager.InsertFaculty(faculty,designation);

            Console.WriteLine("Faculty added successfully");
            Console.WriteLine("\n\n\nPress any key");
            Console.ReadKey();

            Console.Clear();
        }

        public  void DisplayTheListOfFaculties(FacultyManager facultyManager)
        {
            var facultyDetails = facultyManager.GetFacultyDetail();

            foreach (var facultyDetail in facultyDetails)
            {
                Console.WriteLine("The faculty Id is:{0}", facultyDetail.Id);
                Console.WriteLine("The course name is:{0}", facultyDetail.Name);
            }
            Console.WriteLine("\n\n\nPress any key");
            Console.ReadKey();

            Console.Clear();
        }

        public  void UpdateFaculties(FacultyManager facultyManager)
        {
            Console.WriteLine("Updation into the faculty table");
            Faculty faculty = new Faculty();

            Console.WriteLine("Enter faculty ID to be updated");
            faculty.Id = Convert.ToInt32(Console.ReadKey());
            Console.WriteLine("Enter the new faculty name");
            faculty.Name = Console.ReadLine();

            facultyManager.UpdateFaculty(faculty);

            Console.WriteLine("Updated the faculty detail");
            Console.WriteLine("\n\n\nPress any key");
            Console.ReadKey();

            Console.Clear();
        }
    }
}

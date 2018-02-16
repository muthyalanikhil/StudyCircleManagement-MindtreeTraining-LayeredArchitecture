using StudyCircleManagementSystem.BusinessLayer;
using StudyCircleManagementSystem.Entities;
using System;

namespace StudyCircleManagementSystem
{
    class CourseManagement
    {
        public void GetChoice()
        {
            int choice;
            do
            {
                Console.Clear();
                CourseManager courseManager = new CourseManager();
                Console.WriteLine("-------Courses--------");
                Console.WriteLine("1.View The List Of Courses");
                Console.WriteLine("2.Insert New Course");
                Console.WriteLine("3.Delete Course");
                Console.WriteLine("4.Exit courses");
                choice = Convert.ToInt16(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        DisplayTheListOfCourses(courseManager);
                        break;
                    case 2:
                        InsertNewCourse(courseManager);
                        DisplayTheListOfCourses(courseManager);
                        break;
                    case 3:
                        DisplayTheListOfCourses(courseManager);
                        DeleteCourse(courseManager);
                        break;
                }
            }
            while (choice < 4);

        }

        public void DeleteCourse(CourseManager courseManager)
        {
            DisplayTheListOfCourses(courseManager);

            Console.WriteLine();
            Console.WriteLine("Delete the course list");

            Course course = new Course();

            Console.WriteLine("Enter the course name to be deleted");
            course.Name = Console.ReadLine();

            courseManager.DeleteCourse(course);

            Console.WriteLine("Course Deleted successfully");
            Console.WriteLine("\n\n\nPress any key");
            Console.ReadKey();

            Console.Clear();
        }

        public void InsertNewCourse(CourseManager courseManager)
        {
            Console.WriteLine("insert into the course table");
            Course course = new Course();

            Console.WriteLine("Enter the course name");
            course.Name = Console.ReadLine();

            courseManager.InsertCourse(course);

            Console.WriteLine("Course added successfully.");
            Console.WriteLine("\n\n\nPress any key");
            Console.ReadKey();

            Console.Clear();
        }

        public void DisplayTheListOfCourses(CourseManager courseManager)
        {
            var courseDetails = courseManager.GetCourseDetail();

            foreach (var courseDetail in courseDetails)
            {
                Console.WriteLine("The course Id is:{0}", courseDetail.Id);
                Console.WriteLine("The course name is:{0}", courseDetail.Name);
            }
            Console.WriteLine("\n\n\nPress any key");
            Console.ReadKey();

            Console.Clear();
        }
    }
}

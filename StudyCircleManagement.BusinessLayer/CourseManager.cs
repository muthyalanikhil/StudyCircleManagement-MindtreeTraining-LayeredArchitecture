using StudyCircleManagementSystem.DataAccess;
using StudyCircleManagementSystem.Entities;
using System.Collections.Generic;

namespace StudyCircleManagementSystem.BusinessLayer
{
    public class CourseManager
    {
        public List<Course> GetCourseDetail()
        {
            CourseManagerDAO courseDetail = new CourseManagerDAO();
            var courseDetails = courseDetail.GetCourseDetail();            

            return courseDetails;
        }

        public void InsertCourse(Course course)
        {
            CourseManagerDAO courseDetail = new CourseManagerDAO();
            courseDetail.InsertCourse(course);
        }

        public void DeleteCourse(Course course)
        {
            CourseManagerDAO courseDetail = new CourseManagerDAO();
            courseDetail.DeleteCourse(course);
        }
    }
}

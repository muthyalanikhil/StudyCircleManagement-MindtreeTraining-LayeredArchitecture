using StudyCircleManagementSystem.DataAccess;
using StudyCircleManagementSystem.Entities;
using System.Collections.Generic;

namespace StudyCircleManagementSystem.BusinessLayer
{
    public class StudentManager
    {
        public List<Student> GetStudentDetail()
        {
            StudentManagerDAO studentDetail = new StudentManagerDAO();
            var studentDetails = studentDetail.GetStudentDetail();

            return studentDetails;

        }

        public void InsertStudent(Student student)
        {
            StudentManagerDAO studentDetail = new StudentManagerDAO();
            studentDetail.InsertStudent(student);
        }

        public void DeleteStudent(Student student)
        {
            StudentManagerDAO studentDetail = new StudentManagerDAO();
            studentDetail.DeleteStudent(student);
        }
    }
}

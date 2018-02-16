using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyCircleManagementSystem.Entities;
using StudyCircleManagementSystem.DataAccess;

namespace StudyCircleManagementSystem.BusinessLayer
{
    public class FunctionWithStudents
    {
        public List<StudentDetail> GetStudentDetail()
        {
            FunctionWithStudent studentDetail = new FunctionWithStudent();
            var studentDetails = studentDetail.GetStudentDetail();

            return studentDetails;
 
        }

        public void InsertStudent(string studentName, string courseName, long studentPhoneNumber, int testMarks)
        {
            FunctionWithStudent studentDetail = new FunctionWithStudent();
            studentDetail.InsertStudent(studentName,courseName,studentPhoneNumber,testMarks);
        }

        public void DeleteStudent(string studentName)
        {
            FunctionWithStudent studentDetail = new FunctionWithStudent();
            studentDetail.DeleteStudent(studentName);
        }
    }

}

using StudyCircleManagementSystem.DataAccess;
using StudyCircleManagementSystem.Entities;
using System.Collections.Generic;

namespace StudyCircleManagementSystem.BusinessLayer
{
   public class FacultyManager
    {
        public List<Faculty> GetFacultyDetail()
        {
            FacultyManagerDAO facultyDetail = new FacultyManagerDAO();
            var courseDetails = facultyDetail.GetFacultyDetail();

            return courseDetails;
        }

        public void InsertFaculty(Faculty faculty,string designation)
        {
            FacultyManagerDAO facultyDetail = new FacultyManagerDAO();
            facultyDetail.AddFaculty(faculty,designation);
        }

        public void DeleteFaculty(Faculty faculty)
        {
            FacultyManagerDAO facultyDetail = new FacultyManagerDAO();
            facultyDetail.DeleteFaculty(faculty);
        }

        public void UpdateFaculty(Faculty faculty)
        {
            FacultyManagerDAO facultyDetail = new FacultyManagerDAO();
            facultyDetail.FacultyUpdate(faculty);
        }
    }
}

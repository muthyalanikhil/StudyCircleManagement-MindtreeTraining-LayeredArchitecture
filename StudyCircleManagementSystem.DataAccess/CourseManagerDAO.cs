using StudyCircleManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace StudyCircleManagementSystem.DataAccess
{
    public class CourseManagerDAO
    {
        public List<Course> GetCourseDetail()
        {
            List<Course> courseDetails = new List<Course>();

            string connectionString = ConfigurationManager.ConnectionStrings["connectDB"].ToString();

            SqlConnection connection = null;
          
            connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            connection.Open();
            SqlCommand command = new SqlCommand("dbo.course_details", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Connection = connection;
           
            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Course courseDetail = new Course();

                courseDetail.Id = Convert.ToInt32(dataReader["course_id"]);
                courseDetail.Name = dataReader["course_name"].ToString();

                courseDetails.Add(courseDetail);
            }
            connection.Close();
            return courseDetails;
        }


        public void InsertCourse(Course course)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connectDB"].ToString();
            SqlConnection connection = null;

            connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            connection.Open();

            SqlCommand command = new SqlCommand("dbo.add_course", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@course_name", SqlDbType.NVarChar));
            command.Parameters["@course_name"].Value = course.Name;

            command.ExecuteNonQuery();

            connection.Close();

        }

        public void DeleteCourse(Course course)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connectDB"].ToString();
            SqlConnection connection = null;

            connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            connection.Open();

            SqlCommand command = new SqlCommand("dbo.delete_course", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@course_name", SqlDbType.NVarChar));
            command.Parameters["@course_name"].Value = course.Name;

            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}

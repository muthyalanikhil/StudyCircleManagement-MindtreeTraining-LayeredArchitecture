using StudyCircleManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace StudyCircleManagementSystem.DataAccess
{
    public class FacultyManagerDAO
    {
        public List<Faculty> GetFacultyDetail()
        {
            List<Faculty> facultyDetails = new List<Faculty>();

            string connectionString = ConfigurationManager.ConnectionStrings["connectDB"].ToString();

            SqlConnection connection = null;
            SqlCommand command = null;

            connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            connection.Open();
            command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = "SELECT FacultyId,FacultyName from FacultyDetail";
            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Faculty facultyDetail = new Faculty();

                facultyDetail.Id = Convert.ToInt32(dataReader["facultyId"]);
                facultyDetail.Name = dataReader["facultyName"].ToString();

                facultyDetails.Add(facultyDetail);
            }
            connection.Close();
            return facultyDetails;
        }

        public void AddFaculty(Faculty faculty,string designation)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connectDB"].ToString();

            SqlConnection connection = null;
            SqlCommand command = null;

            connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            connection.Open();
            command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = "INSERT INTO FacultyDetail (FacultyName) VALUES (@FacultyName) INSERT INTO passwordDetails(UserName,Designation) values (@FacultyName,@Designation)";
            command.Parameters.AddWithValue("@FacultyName", faculty.Name);
            command.Parameters.AddWithValue("@Designation", designation);

            command.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteFaculty(Faculty faculty)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connectDB"].ToString();

            SqlConnection connection = null;
            SqlCommand command = null;

            connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            connection.Open();
            command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = "DELETE FROM FacultyDetail WHERE FacultyName=@FacultyName";

            command.Parameters.AddWithValue("@FacultyName", faculty.Name);

            command.ExecuteNonQuery();
            connection.Close();
        }
        public void FacultyUpdate(Faculty faculty)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connectDB"].ToString();

            SqlConnection connection = null;
            SqlCommand command = null;

            connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            connection.Open();
            command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = "UPDATE FacultyDetail SET FacultyName=@FacultyName WHERE FacultyId=@FacultyId ";

            command.Parameters.AddWithValue("@FacultyName", faculty.Name);
            command.Parameters.AddWithValue("@FacultyId", faculty.Id);

            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}

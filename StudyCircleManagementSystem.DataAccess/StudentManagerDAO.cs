using StudyCircleManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace StudyCircleManagementSystem.DataAccess
{
    public class StudentManagerDAO
    {
        public List<Student> GetStudentDetail()
        {
            List<Student> studentDetail = new List<Student>();

            SqlConnection conn = new SqlConnection();
            string connectionString = ConfigurationManager.ConnectionStrings["connectDB"].ToString();

            conn = new SqlConnection();
            conn.ConnectionString = connectionString;

            conn.Open();

            string query = "select Student_Id,Student_Name,Student_Course,Student_Phone_No,Student_Test_Marks FROM Student_Detail ";
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            System.Data.DataTable table = new System.Data.DataTable();
            dataAdapter.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                Student studentDetails = new Student();
                studentDetails.Id = Convert.ToInt32(row["Student_Id"].ToString());
                studentDetails.Name = row["Student_Name"].ToString();
                studentDetails.CourseName = row["Student_Course"].ToString();
                studentDetails.PhoneNumber = Convert.ToInt64(row["Student_Phone_No"].ToString());
                studentDetails.TestMarks = Convert.ToInt32(row["Student_Test_Marks"].ToString());

                studentDetail.Add(studentDetails);
            }

            return studentDetail;

        }

        public void InsertStudent(Student student)
        {
            SqlConnection conn = new SqlConnection();

            string connectionString = ConfigurationManager.ConnectionStrings["connectDB"].ToString();
            conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            command.CommandText = "INSERT INTO Student_Detail (Student_Name, Student_Course,Student_Phone_No,Student_Test_Marks) values (@Student_Name,@Student_Course,@Student_Phone_No,@Student_Test_Marks) INSERT INTO passwordDetails(UserName,Designation) values (@Student_Name,'student') ";

            command.Parameters.AddWithValue("@Student_Name", student.Name);
            // @Student_Course,@Student_Phone_No,@Student_Test_Marks", studentName, courseName, studentPhoneNumber, testMarks);
            command.Parameters.AddWithValue("@Student_Course", student.CourseName);
            command.Parameters.AddWithValue("@Student_Phone_No", student.PhoneNumber);
            command.Parameters.AddWithValue("@Student_Test_Marks", student.TestMarks);



            command.ExecuteNonQuery();

            conn.Close();
        }

        public void DeleteStudent(Student student)
        {
            SqlConnection conn = new SqlConnection();
            string connectionString = ConfigurationManager.ConnectionStrings["connectDB"].ToString();

            conn = new SqlConnection();
            conn.ConnectionString = connectionString;

            conn.Open();
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "DELETE FROM Student_Detail where Student_Name=@Student_Name";
            command.Parameters.AddWithValue("@Student_Name", student.Name);

            command.ExecuteNonQuery();
            conn.Close();

        }
    }
}

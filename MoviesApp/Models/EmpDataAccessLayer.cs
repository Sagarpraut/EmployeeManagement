using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class EmpDataAccessLayer
    {
        string connectionString = "Server=FSIND-LT-08\\SQLEXPRESS;Database=EmpDB;Trusted_Connection=True;";

        public void AddEmp(Employee Emp)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FIRSTNAME", Emp.Firstnme);
                cmd.Parameters.AddWithValue("@MIDDLE", Emp.Middle);
                cmd.Parameters.AddWithValue("@LASTNAME", Emp.Lastname);
                cmd.Parameters.AddWithValue("@WORKDEPT", Emp.Workdept);
                cmd.Parameters.AddWithValue("@PHONENO", Emp.Phoneno);
                cmd.Parameters.AddWithValue("@JOB", Emp.Job);
                cmd.Parameters.AddWithValue("@SALARY", Emp.Salary);

                con.Open();
                cmd.ExecuteNonQuery();
               
                con.Close();
            }
        }
    }
}

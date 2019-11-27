using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class DataAccessSql
    {
        string connectionString = "Server=FSIND-LT-08\\SQLEXPRESS;Database=EmpDB;Trusted_Connection=True;";
        public bool CheckLogin(Registration user)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                
                SqlCommand cmd = new SqlCommand("SELECT * FROM Registration WHERE EmailID=@val1 AND pass=(@val2)",con);
                SqlParameter emailParameter = cmd.Parameters.Add("@val1", SqlDbType.VarChar,30);
                emailParameter.Value = user.EmailId;
                SqlParameter passParameter = cmd.Parameters.Add("@val2", SqlDbType.VarChar,30);
                passParameter.Value = user.Pass;

                con.Open();
                cmd.Prepare();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string email = rdr["EmailID"].ToString();
                    string pass = rdr["Pass"].ToString();

                    if (email == user.EmailId && pass == user.Pass)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
        }

        public void AddUser(Registration user)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@EmailID", user.EmailId);
                cmd.Parameters.AddWithValue("@Pass", user.Pass);



                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}

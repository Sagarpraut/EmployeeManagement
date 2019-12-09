using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoviesApp.Models
{ 
    public class DataAccessSql : IUserDataAccessLayer
    {
        string connectionString = "Server=FSIND-LT-08\\SQLEXPRESS;Database=EmpDB;Trusted_Connection=True;";
        public bool CheckLogin(Registration user)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("SELECT * FROM Registration WHERE EmailID=@val1 AND pass=(@val2)", con);
                SqlParameter emailParameter = cmd.Parameters.Add("@val1", SqlDbType.VarChar, 30);
                emailParameter.Value = user.EmailId;
                SqlParameter passParameter = cmd.Parameters.Add("@val2", SqlDbType.VarChar, 30);
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
            {
                if (string.IsNullOrEmpty(user.EmailId) || !Regex.IsMatch(user.EmailId, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                {
                    throw new ArgumentNullException("Email Id Cannot be Null or Empty");
                }
                else if (string.IsNullOrEmpty(user.FirstName))
                {
                    throw new ArgumentNullException("First Name Cannot be Null or Empty");
                }
                else if (string.IsNullOrEmpty(user.LastName))
                {
                    throw new ArgumentNullException("Last Name Cannot be Null or Empty");

                }
              /*  else if (user.Pass.Length < 6)
                {
                    throw new ArgumentException("Password Length Should be More than 6");
                }
                */    
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

            //session management
            public Registration GetUserDetails(string emailId)
            {
                Registration user = new Registration();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Registration WHERE EmailId =@id", con);
                    SqlParameter idParameter = cmd.Parameters.Add("@id", SqlDbType.VarChar, 30);
                    idParameter.Value = emailId;
                    con.Open();
                    cmd.Prepare();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", user.LastName);
                        cmd.Parameters.AddWithValue("@EmailID", user.EmailId);
                        cmd.Parameters.AddWithValue("@Pass", user.Pass);

                    }
                    cmd.Dispose();
                }

                return user;
            }

        }
    }

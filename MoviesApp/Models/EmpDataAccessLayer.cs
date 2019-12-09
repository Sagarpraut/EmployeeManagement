using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class EmpDataAccessLayer : IEmpDataAccessLayer
    {
        string connectionString = "Server=FSIND-LT-08\\SQLEXPRESS;Database=EmpDB;Trusted_Connection=True;";

        public bool AddEmp(Employee Emp)
        {
            if (string.IsNullOrEmpty(Emp.Firstnme))
            {
                throw new ArgumentNullException(Emp.Firstnme);
            }
            else if (string.IsNullOrEmpty(Emp.Middle))
            {
                throw new ArgumentNullException(Emp.Middle);
            }
            else if (string.IsNullOrEmpty(Emp.Lastname))
            {
                throw new ArgumentNullException(Emp.Lastname);
            }

            using SqlConnection con = new SqlConnection(connectionString);
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FIRSTNME", Emp.Firstnme);
                cmd.Parameters.AddWithValue("@MIDDLE", Emp.Middle);
                cmd.Parameters.AddWithValue("@LASTNAME", Emp.Lastname);
                cmd.Parameters.AddWithValue("@WORKDEPT", Emp.Workdept);
                cmd.Parameters.AddWithValue("@PHONENO", Emp.Phoneno);
                cmd.Parameters.AddWithValue("@JOB", Emp.Job);
                cmd.Parameters.AddWithValue("@SALARY", Emp.Salary);

                con.Open();
                cmd.ExecuteNonQuery();

                con.Close();

                return true;
            }
        }

        public void UpdateEmployee(Employee emp)
        {

            Debug.WriteLine(emp.Firstnme + emp.Middle + emp.Lastname + emp.Workdept + emp.Phoneno + emp.Job + emp.Salary + emp.Empno);


            using SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FIRSTNME", emp.Firstnme);
            cmd.Parameters.AddWithValue("@MIDDLE", emp.Middle);
            cmd.Parameters.AddWithValue("@LASTNAME", emp.Lastname);
            cmd.Parameters.AddWithValue("@WORKDEPT", emp.Workdept);
            cmd.Parameters.AddWithValue("@PHONENO", emp.Phoneno);
            cmd.Parameters.AddWithValue("@JOB", emp.Job);
            cmd.Parameters.AddWithValue("@SALARY", emp.Salary);
            cmd.Parameters.AddWithValue("@EMPNO", emp.Empno);


            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

        }
        public Employee GetEmployeeData(int? EMPNO)
        {
            Employee emp = new Employee();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM EMPLOYEE WHERE EMPNO = @EMPNO", con);
                SqlParameter idParameter = cmd.Parameters.Add("@EMPNO", SqlDbType.Int);
                idParameter.Value = EMPNO;
                con.Open();
                cmd.Prepare();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    emp.Empno = Convert.ToInt32(rdr["EMPNO"]);
                    emp.Firstnme = rdr["FIRSTNME"].ToString();
                    emp.Middle = rdr["MIDDLE"].ToString();
                    emp.Lastname = rdr["LASTNAME"].ToString();
                    emp.Workdept = rdr["WORKDEPT"].ToString();
                    emp.Job = rdr["JOB"].ToString();
                    emp.Phoneno = rdr["PHONENO"].ToString();
                    emp.Salary = Convert.ToDecimal(rdr["Salary"]);

                }
                cmd.Dispose();
            }

            return emp;
        }


        public void Delete(int? id)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EMPNO", id);

            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public IEnumerable<Employee> Employee()
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Employee emp = new Employee();

                    emp.Empno = Convert.ToInt32(rdr["EMPNO"]);
                    emp.Firstnme = rdr["FIRSTNME"].ToString();
                    emp.Middle = rdr["MIDDLE"].ToString();
                    emp.Lastname = rdr["LASTNAME"].ToString();
                    emp.Workdept = rdr["WORKDEPT"].ToString();
                    emp.Job = rdr["JOB"].ToString();
                    emp.Phoneno = rdr["PHONENO"].ToString();
                    emp.Salary = Convert.ToDecimal(rdr["Salary"]);

                    employees.Add(emp);
                }
                cmd.Dispose();
                con.Close();
            }
            return employees;
        }


    }
}




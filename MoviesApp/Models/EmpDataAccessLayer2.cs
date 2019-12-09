using System;
using System.Collections.Generic;
using System.Linq;

namespace MoviesApp.Models
{
    public class EmpDataAccessLayer2 : IEmpDataAccessLayer
    {
        EmpDBContext empDBContext;

        public EmpDataAccessLayer2(EmpDBContext context)
        {
            empDBContext = context;
        }
        public bool AddEmp(Employee employee)
        {
            if (string.IsNullOrEmpty(employee.Firstnme))
            {
                throw new ArgumentNullException("First Nameshould not be null ");
            }

            if(string.IsNullOrEmpty(employee.Lastname))
            {
                throw new ArgumentNullException("Last Name should not be null ");
            }

            if (string.IsNullOrEmpty(employee.Middle))
            {
                throw new ArgumentNullException("Last Name should not be null ");
            }

            empDBContext.Add(employee);
            empDBContext.SaveChanges();

            return true;
        }



        public IEnumerable<Employee> Employee()
        {
            return empDBContext.Employee.ToList(); ;
        }



        public void Delete(int? id)
        {
            var emp = empDBContext.Employee.Find(id);
            empDBContext.Employee.Remove(emp);
            empDBContext.SaveChanges();
        }



        public void UpdateEmployee(Employee employee)
        {
            empDBContext.Update(employee);
            empDBContext.SaveChanges();
        }


        public Employee GetEmployeeData(int? id)
        {
            Employee employee = empDBContext.Employee.Find(id);
            return employee;
        }
    }
}


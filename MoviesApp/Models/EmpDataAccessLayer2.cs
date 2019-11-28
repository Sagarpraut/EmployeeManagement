using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class EmpDataAccessLayer2
    {
        EmpDBContext empDBContext;

        public EmpDataAccessLayer2(EmpDBContext context)
        {
            empDBContext = context;
        }


        public void AddEmp(Employee employee)
        {
            empDBContext.Add(employee);
            empDBContext.SaveChanges();
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


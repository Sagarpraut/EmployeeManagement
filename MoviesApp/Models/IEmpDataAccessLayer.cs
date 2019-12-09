using System.Collections.Generic;

namespace MoviesApp.Models
{
    public interface IEmpDataAccessLayer
    {
        bool AddEmp(Employee Emp);
        void Delete(int? id);
        IEnumerable<Employee> Employee();
        Employee GetEmployeeData(int? EMPNO);
        void UpdateEmployee(Employee emp);
    }
}
using MoviesApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestEmployee
{
    public class UnitTest1
    {
        [Fact]
        public void Test_Invalid_EmpName()
        {
            var empDataAcess = new EmpDataAccessLayer2(new EmpDBContext());
            Employee employee = new Employee() {Lastname ="Raut",Middle ="PR", Job = "IT",Empno = 1,Phoneno = "8007885744",Salary = 20000 ,Workdept="IT" };
            Assert.Throws<ArgumentNullException>(() => empDataAcess.AddEmp(employee));

        }
        

    }

}

using Moq;
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
        public void Test_Invalid_FirstName()
        {
            var empDataAcess = new EmpDataAccessLayer2(new EmpDBContext());
            Employee employee = new Employee() { Lastname = "Raut", Middle = "PR", Job = "IT", Empno = 1, Phoneno = "8007885744", Salary = 20000, Workdept = "IT" };
            Assert.Throws<ArgumentNullException>(() => empDataAcess.AddEmp(employee));
        }

        [Fact]
        public void Test_Invalid_LastName()
        {
            var empDataAcess = new EmpDataAccessLayer2(new EmpDBContext());
            Employee employee = new Employee() { Firstnme = "UnitTest", Middle = "PR", Job = "IT", Empno = 1, Phoneno = "8007885744", Salary = 20000, Workdept = "IT" };
            Assert.Throws<ArgumentNullException>(() => empDataAcess.AddEmp(employee));
        }

        [Fact]
        public void Test_Invalid_MiddleName()
        {
            var empDataAcess = new EmpDataAccessLayer2(new EmpDBContext());
            Employee employee = new Employee() { Firstnme = "UnitTest", Lastname = "Test", Job = "IT", Empno = 1, Phoneno = "8007885744", Salary = 20000, Workdept = "IT" };
            Assert.Throws<ArgumentNullException>(() => empDataAcess.AddEmp(employee));
        }


        [Fact]
        public void Test_Invaild_Emp()
        {


        }

        [Fact]
        public void Test_Valid_Emp()
        {
            var mockEmp = new Mock<Employee>();

            var empdataaccesslayer2 = new Mock<IEmpDataAccessLayer>();
            empdataaccesslayer2.Setup(dal => dal.AddEmp(It.IsAny<Employee>()))
                .Returns(true);

            Employee employee = new Employee { Firstnme = "UnitTest", Middle = "Ss", Lastname = "Test", Job = "IT", Empno = 1, Phoneno = "8007885744", Salary = 20000, Workdept = "IT" };
            Assert.True(empdataaccesslayer2.Object.AddEmp(employee));
        }
    }
}




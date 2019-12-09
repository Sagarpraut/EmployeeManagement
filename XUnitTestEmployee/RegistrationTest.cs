using MoviesApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace XUnitTestEmployee
{
   public class RegistrationTest 
    {
        [Fact]
        public void Test_Invalid_Email()
        {
            
            var dataacessLayer = new DataAccessSql();
            Registration user = new Registration { FirstName = "AmitTset", LastName = "ADSS", Pass = "Amit123" };
            Assert.Throws<ArgumentNullException>(() => dataacessLayer.AddUser(user));
        }

         /* [Fact]
           public void Test_Invalid_Pass()
           {
               var dataacessLayer = new DataAccessSql();
               Registration user = new Registration { FirstName = "AmitTset", Pass = "Amit123",LastName = "ADSS",EmailId ="Sagar@gmail.com" };
               Assert.Throws<ArgumentException>(() => dataacessLayer.AddUser(user));
           }
           */

        [Fact]
        public void Test_Invalid_FirstName()
        {
            var dataacessLayer = new DataAccessSql();
            Registration user = new Registration { LastName = "ADSS", Pass = "Amit123",EmailId="Sagar@gmail.com" };
            Assert.Throws<ArgumentNullException>(() => dataacessLayer.AddUser(user));
        }

        [Fact]
        public void Test_Invalid_LastName()
        {
            var dataacessLayer = new DataAccessSql();
            Registration user = new Registration { FirstName = "AmitTset" , Pass = "Amit123", EmailId = "Sagar@gmail.com" };
            Assert.Throws<ArgumentNullException>(() => dataacessLayer.AddUser(user));
        }




    }
}

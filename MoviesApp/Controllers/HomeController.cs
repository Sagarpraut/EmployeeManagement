using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoviesApp.Models;

namespace MoviesApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        DataAccessSql dataAccessSql = new DataAccessSql();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            UserDataAccessLayer userDataAccessLayer = new UserDataAccessLayer();

            string email = user.EmailID;
            string pass = user.Password;

            bool success = userDataAccessLayer.checkUserLogin(email, pass);

            if (success)
                return RedirectToAction("Index", "Employees");
            else
            {
                ViewData["Error"] = "Invalid Details";
                return View();
            }


        }



        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Register(User user)
        {
            UserDataAccessLayer userDataAccessLayer = new UserDataAccessLayer();


            userDataAccessLayer.addUser(user);

            ViewData["EmailID"] = user.EmailID;

            return View("Login");
        }





        public IActionResult ChangePassword()
        {
            return View();
        }





        public IActionResult RegisterSql()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterSql(Registration user)
        {
            dataAccessSql.AddUser(user);
            return View("LoginSql");
        }

        public IActionResult LoginSql()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginSql(Registration user)
        {
            bool success = dataAccessSql.CheckLogin(user);

            if (success)
            {
                return RedirectToAction("Index", "Employees");
            }
            else
            {
                ViewData["Error"] = "Invalid Details";
                return View();
            }
            
        }


       


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}















/*
 SQL
[HttpPost]
public IActionResult Login(User user)
{
    DataAccessSql dataAccess = new DataAccessSql();
    bool success = dataAccess.CheckLogin(user);
    if (success)
    {
        return RedirectToAction("Index", "Employee");
    }
    else
    {
        ViewData["Error"] = "Invalid Details";
        return View();
    }
}*/


/*
JSON
      [HttpPost]
        public ActionResult Login(User user)
        {
            UserDataAccessLayer userDataAccessLayer = new UserDataAccessLayer();

            string email = user.EmailID;
            string pass = user.Password;

            bool success = userDataAccessLayer.checkUserLogin(email, pass);

            if (success)
                return RedirectToAction("Index","Employees");
            else
            {
                ViewData["Error"] = "Invalid Details";
                return View();
            }


        }*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoviesApp.Models;
using MediatR;


namespace MoviesApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        DataAccessSql dataAccessSql = new DataAccessSql();

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegisterSql()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterSql(RegisterRequestModel user)
        {
            _mediator.Send(user);
            return View("LoginSql");
        }

        public IActionResult LoginSql()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginSql(LoginRequestModel user)
        {
           

            var result = _mediator.Send(user);
            bool success = result.Result.Success;

            if (success)
            {
                HttpContext.Session.SetString("email", user.EmailId); //session managament
             //  TempData["User"] = LoginHandler.email;
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

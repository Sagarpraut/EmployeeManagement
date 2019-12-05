using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Models;

namespace MoviesApp.Controllers
{
    public class EmployeesController : Controller
    {
        IEmpDataAccessLayer empDataAccessLayer;

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public EmployeesController(IMediator mediator, IMapper mapper, IEmpDataAccessLayer _empDataAccessLayer)
        {
            empDataAccessLayer = _empDataAccessLayer;
            _mediator = mediator;
            _mapper = mapper;
        }

        // GET: Employees
        public IActionResult Index()
        {
            if (checkInvalidSession())
            {
                return RedirectToAction("Index", "Home");
            }
         
            return View(empDataAccessLayer.Employee());

        }
        // GET: Employees/Details/5
        public IActionResult Details(int? id)
        {
            if (checkInvalidSession())
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null)
            {
                return NotFound();
            }

            var employee = _mediator.Send(new GetEmpDetailsRequestModel { EmpId = id });
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee.Result);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            if (checkInvalidSession())
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        EmpDataAccessLayer objemp = new EmpDataAccessLayer();

        [HttpPost]

        public ActionResult Create(EmployeeRequestModel emp)
        {
            if (checkInvalidSession())
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {


                _mediator.Send(emp);

                return RedirectToAction("index");
            }
            else
            {
                return View(emp);
            }

        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {

            if (checkInvalidSession())
            {
                return RedirectToAction("Index", "Home");
            }

            var stud = _mediator.Send(new GetEmpDetailsRequestModel { EmpId = id });
            return View(_mapper.Map<EditEmpRequestModel>(stud.Result));


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Empno, EditEmpRequestModel emp)
        {
            if (checkInvalidSession())
            {
                return RedirectToAction("Index", "Home");
            }
            if (Empno != emp.Empno)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _mediator.Send(emp);

                return RedirectToAction("Index");
            }
            return View("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (checkInvalidSession())
            {
                return RedirectToAction("Index", "Home");
            }
            
            _mediator.Send(new DeleteEmpRequestModel { EmpId = id });

            return RedirectToAction("Index");
        }

        //session management
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("email");
            return RedirectToAction("Index", "Home");
        }
        public bool checkInvalidSession()
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                TempData["SessionError"] = "Invalid Session. Login Again";
                return true;
            }
            else return false;
        }

    }
}

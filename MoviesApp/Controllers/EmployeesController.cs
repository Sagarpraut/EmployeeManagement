using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Models;

namespace MoviesApp.Controllers
{
    public class EmployeesController : Controller
    {
        //EmpDataAccessLayer empDataAccessLayer = new EmpDataAccessLayer();
        EmpDataAccessLayer2 empDataAccessLayer;
        public EmployeesController(EmpDBContext context)
        {
            empDataAccessLayer = new EmpDataAccessLayer2(context);
        }

        // GET: Employees
        public IActionResult Index()
        {
            return View(empDataAccessLayer.Employee());
        }
        
        // GET: Employees/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = empDataAccessLayer.GetEmployeeData(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }
        EmpDataAccessLayer objemp = new EmpDataAccessLayer();

        [HttpPost]
       
        public IActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                objemp.AddEmp(emp);
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

          Employee emp = objemp.GetEmployeeData(id);

            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Empno, [Bind]Employee emp)
        {
            if (Empno != emp.Empno)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                objemp.UpdateEmployee(emp);
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            objemp.Remove(id);
            return RedirectToAction("Index");
        }



        /*
        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Firstnme,Middle,Lastname,Workdept,Phoneno,Job,Salary,Empno")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }
        */
        // GET: Employees/Edit/5
        /*  public async Task<IActionResult> Edit(int? id)
          {
              if (id == null)
              {
                  return NotFound();
              }

              var employee = await _context.Employee.FindAsync(id);
              if (employee == null)
              {
                  return NotFound();
              }
              return View(employee);
          }

          // POST: Employees/Edit/5
          // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
          // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
          [HttpPost]
          [ValidateAntiForgeryToken]
          public async Task<IActionResult> Edit(int id, [Bind("Firstnme,Middle,Lastname,Workdept,Phoneno,Job,Salary,Empno")] Employee employee)
          {
              if (id != employee.Empno)
              {
                  return NotFound();
              }

              if (ModelState.IsValid)
              {
                  try
                  {
                      _context.Update(employee);
                      await _context.SaveChangesAsync();
                  }
                  catch (DbUpdateConcurrencyException)
                  {
                      if (!EmployeeExists(employee.Empno))
                      {
                          return NotFound();
                      }
                      else
                      {
                          throw;
                      }
                  }
                  return RedirectToAction(nameof(Index));
              }
              return View(employee);
          }
          */
        // GET: Employees/Delete/5

        /*
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var employee = await _context.Employee
            .FirstOrDefaultAsync(m => m.Empno == id);
        if (employee == null)
        {
            return NotFound();
        }

        return View(employee);
    }

    // POST: Employees/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var employee = await _context.Employee.FindAsync(id);
        _context.Employee.Remove(employee);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    */
      /*  private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.Empno == id);
        }*/
    }
}

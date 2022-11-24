using MVCentityFrameworkNewProject.Data;
using MVCentityFrameworkNewProject.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MVCentityFrameworkNewProject.Controllers
{
   
    public class EmployeeCtlController : Controller
    {
        private readonly ApplicationDbContext context;
        public EmployeeCtlController()
        {
            context = new ApplicationDbContext();
        }

        // Disposing the Context Resources
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }
        // GET: EmployeeCtl
      
        public ActionResult Index()
        {
            //Create List
            var employeeList = context.Employees.Include(e => e.Department).Include(e => e.Designation).ToList();
            return View(employeeList);

        }
        public ActionResult Upsert(int? id)
        {
            ViewData["depList"] = context.Departments.ToList();
            ViewData["desList"] = context.Designations.ToList();
            Employee employee = new Employee();

            // Create
            if (id == null) return View(employee);

            //Edit
            employee = context.Employees.Include(e => e.Department).Include(e => e.Designation).FirstOrDefault(e => e.Id == id);
            if (employee == null) return HttpNotFound();
            return View(employee);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upsert(Employee employee)
        {
            if (employee == null) return HttpNotFound();
            if (!ModelState.IsValid)
            {
                ViewData["depList"] = context.Departments.ToList();
                //ViewData["desList"] = context.Designations.ToList();
                ViewBag.desList = context.Designations.ToList();
                View(employee);
            }

            // Save
            if (employee.Id == 0) context.Employees.Add(employee);
            else
            {
                //Update
                var employeeInDb = context.Employees.Find(employee.Id);
                if (employeeInDb == null) return HttpNotFound();
                employeeInDb.Name = employee.Name;
                employeeInDb.Address = employee.Address;
                employeeInDb.Salary = employee.Salary;
                employeeInDb.DepartmentId = employee.DepartmentId;
                employeeInDb.DesignationId = employee.DesignationId;
            }
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Details(int id)
        {
            var empInDb = context.Employees.Include(e=>e.Department).Include(e=>e.Designation).FirstOrDefault(e=>e.Id == id);   
            if(empInDb == null) return HttpNotFound();
            return View(empInDb);
        }
        public ActionResult Delete(int id)
        {
            var empInDB = context.Employees.Find(id);
            if (empInDB == null) return HttpNotFound();
            context.Employees.Remove(empInDB);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
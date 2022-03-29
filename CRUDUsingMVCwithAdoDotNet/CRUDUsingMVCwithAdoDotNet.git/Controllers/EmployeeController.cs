using CRUDUsingMVCwithAdoDotNet.git.Models;
using CRUDUsingMVCwithAdoDotNet.git.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDUsingMVCwithAdoDotNet.git.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee/GetEmployees
        [HttpGet]
        public ActionResult GetEmployees()
        {
            EmployeeRepository repo = new EmployeeRepository();
            ModelState.Clear();

            return View(repo.GetEmployees());
        }

        //GET: Employee/AddEmployee
        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }

        //POST: Employee/AddEmployee
        [HttpPost]
        public ActionResult AddEmployee(EmployeeModel employee)
        {
            if (ModelState.IsValid) { 
            EmployeeRepository repo = new EmployeeRepository();
            if (repo.AddEmployee(employee))
                ViewBag.Message = "Employee added successfully";

            return View();
            }
            return View(employee);
        }

        //GET: Employee/EditEmployee/1
        [HttpGet]
        public ActionResult EditEmployee(int id)
        {
            EmployeeRepository repo = new EmployeeRepository();
            return View(repo.GetEmployees().Find(e => e.Id == id));
        }

        //POST: Employee/EditEmployee/1
        [HttpPost]
        public ActionResult EditEmployee(int id, EmployeeModel employee)
        {
            try
            {
                EmployeeRepository repo = new EmployeeRepository();
                repo.UpdateEmployee(employee);

                return RedirectToAction("GetEmployees");
            }
            catch
            {
                return View();
            }
        }

        //GET: Employee/DeleteEmployee/5
        [HttpGet]
        public ActionResult DeleteEmployee(int id)
        {
            try
            {
                EmployeeRepository repo = new EmployeeRepository();
                return View(repo.GetEmployees().Find(e => e.Id == id));
            }
            catch
            {
                return View();
            }
        }

        //POST: Employee/DeleteEmployee/5
        [HttpPost]
        public ActionResult DeleteEmployee(int id, EmployeeModel employeeModel)
        {
            EmployeeRepository repo = new EmployeeRepository();

            if (repo.DeleteEmployee(id))
                ViewBag.AlertMsg = "Employee deleted successfully";
            return RedirectToAction("GetEmployees");
        }
    }
}
using MVCwithDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCwithDatabase.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            List<Employee> list = Employee.GetEmployees();
            return View(list);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id = 0)
        {
            Employee e = Employee.GetSingleEmployee(id);
            return View(e);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(Employee obj)
        {
            try
            {
                // TODO: Add insert logic here
                Employee.InsertEmployee(obj);
               // ViewBag.message = "Insertion Sucessfull";
               // return View();

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                //ViewBag.message = e.Message;
                //return View();
                return RedirectToAction("Index");
            }
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            Employee e = Employee.GetSingleEmployee(id);
            return View(e);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee e)
        {
            try
            {
                // TODO: Add update logic here
                Employee.UpdateEmployee(id, e);
                return RedirectToAction("Index");
            }
            catch 
            {
                return View();
            }
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            Employee e = Employee.GetSingleEmployee(id);
            return View(e);

        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Employee e=null)
        {
            try
            {
                // TODO: Add delete logic here
                Employee.DeleteEmployee(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }
    }
}

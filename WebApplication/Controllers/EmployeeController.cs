using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.DataAccess;
using WebApplication.Entity;
using WebApplication.Models;
using static WebApplication.Entity.EmployeeEntity;

namespace WebApplication.Controllers
{
    public class EmployeeController : Controller
    {
        TestEntities db = new TestEntities();
        /// <summary>
        /// Insert Employee
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult InsertEmployee()
        {
            var check = db.Departments.Where(m => m.isDeleted == 0).Select(m => new{ m.departmentName,m.Id}).ToList();
            ViewBag.departmentList = check;
            return View();
        }

        /// <summary>
        /// Insert Employee
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult InsertEmployee(EmployeeCustom data)
        {
            EmployeeDAL employeeDAL = new EmployeeDAL();
            string result = employeeDAL.InsertEmployee(data);
            ViewData["result"] = result;
            ModelState.Clear();
            return View();
        }

        /// <summary>
        /// Get All Employee
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetAllEmployee()
        {
            EmployeeDAL employeeDAL = new EmployeeDAL();
            ModelState.Clear();
            return View(employeeDAL.GetAllEmployee());
        }

        /// <summary>
        /// Update Employee
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult UpdateEmployee(int id)
        {
            EmployeeDAL employeeDAL = new EmployeeDAL();
            return View(employeeDAL.GetEmployeeById(id));
        }

        [HttpPost]
        public ActionResult UpdateEmployee(EmployeeCustom data)
        {
            EmployeeDAL employeeDAL = new EmployeeDAL();
            string result = employeeDAL.UploadEmployee(data);
            ViewData["result"] = result;
            ModelState.Clear();
            return View();
        }

        /// <summary>
        /// Delete Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DeleteEmployee(int id)
        {
            EmployeeDAL employeeDAL = new EmployeeDAL();
            string result = employeeDAL.DeleteEmployee(id);
            ViewData["result"] = result;
            ModelState.Clear();
            return RedirectToAction("GetAllEmployee");
        }
    }
}
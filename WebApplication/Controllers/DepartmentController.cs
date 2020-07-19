using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.DataAccess;
using static WebApplication.Entity.DepartmentEntity;

namespace WebApplication.Controllers
{
    public class DepartmentController : Controller
    {
        /// <summary>
        /// Insert Department
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult InsertDepartment()
        {
            return View();
        }

        /// <summary>
        /// Insert Department
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public ActionResult InsertDepartment(DepartmentCustom data)
        {
            DepartmentDAL departmentDAL = new DepartmentDAL();
            string result = departmentDAL.InsertDepartment(data);
            ViewData["result"] = result;
            ModelState.Clear();
            return View();
        }

        /// <summary>
        /// Update Department
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult UpdateDepartment(int id)
        {
            DepartmentDAL departmentDAL = new DepartmentDAL();
            return View(departmentDAL.GetDepartmentById(id));
        }

        /// <summary>
        /// Update Department
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateDepartment(DepartmentCustom data)
        {
            DepartmentDAL departmentDAL = new DepartmentDAL();
            string result = departmentDAL.UpdateDepartment(data);
            ViewData["result"] = result;
            ModelState.Clear();
            return View();
        }

        /// <summary>
        /// Delete Department
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteDepartment(int id)
        {
            DepartmentDAL departmentDAL = new DepartmentDAL();
            string result = departmentDAL.DeleteDepartment(id);
            ViewData["result"] = result;
            ModelState.Clear();
            return RedirectToAction("GetAllDepartment");
        }

        /// <summary>
        /// Get All Department
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllDepartment()
        {
            DepartmentDAL departmentDAL = new DepartmentDAL();
            ModelState.Clear();
            return View(departmentDAL.GetAllDepartment());
        }
    }
}
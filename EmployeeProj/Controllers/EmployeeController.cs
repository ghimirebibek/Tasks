using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeProj.Models;
using EmployeeProj.Repository;

namespace EmployeeProj.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeRepository _empRepo = new EmployeeRepository();
        // GET: Employee
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("../User/Index");
                
            }     
        }


        public JsonResult GetEmpList()
        {
            var list = _empRepo.GetList();
            return Json(list,JsonRequestBehavior.AllowGet);
        }

        public JsonResult InsertEmployee(EmployeeModel em) 
        {
            _empRepo.InsertEmp(em);
            return Json("Inserted Successfully",JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEmpById(int empId)
        {
            var data = _empRepo.GetEmpById(empId);
            return Json(data,JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateEmployee(EmployeeModel em)
        {
            _empRepo.UpdateEmp(em);
            return Json("Updated Successfully!", JsonRequestBehavior.AllowGet);
        }
    }
}
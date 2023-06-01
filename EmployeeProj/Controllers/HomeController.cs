using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeProj.Controllers
{
    
    public class HomeController : Controller
    {
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

        public ActionResult About()
        {
            if (Session["UserID"] != null)
            {
                ViewBag.Message = "Your application description page.";
                return View();
            }
            else
            {

                

                return RedirectToAction("../User/Index");
            }
        }

        public ActionResult Contact()
        {
            if (Session["UserID"] != null)
            {
                ViewBag.Message = "Your contact page.";
                return View();
            }
            else
            {
                return RedirectToAction("../User/Index");
            }
                
        }
    }
}
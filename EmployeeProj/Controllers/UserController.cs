using EmployeeProj.Models;
using EmployeeProj.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeProj.Controllers
{
    public class UserController : Controller
    {
        UserRepository _userRepo = new UserRepository();
        // GET: User
        
        public ActionResult Index(UserModel log)
        {
            if (log.username == null)
            {
                return View();
            }
            else
            {
                var data = _userRepo.login(log.username, log.password);
                if (data == null)
                {
                    ViewBag.Error = "Unauthorized user";
                    return View();
                }
                else
                {
                    Session["username"] = data.username;
                    Session["userId"] = data.userId;
                    return RedirectToAction("../Employee/Index");
                }
            }
            
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("./Index");
        }
    }
}
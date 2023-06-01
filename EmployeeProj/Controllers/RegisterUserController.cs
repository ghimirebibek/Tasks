using EmployeeProj.Models;
using EmployeeProj.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeProj.Controllers
{
    public class RegisterUserController : Controller
    {
        UserRepository _userRepo = new UserRepository();
        // GET: RegisterUser

        public ActionResult Index(UserModel um)
        {
            if (um.username != null) {
                var data = _userRepo.RegisterUser(um.username, um.password);
                if (data == 0)
                {
                    ViewBag.Error = "Username already Exists!";
                    return View();
                }
                else
                {
                    return RedirectToAction("../User/Index");
                }
            }
            else
            {
                return View();
            }
            
        }
    }
}
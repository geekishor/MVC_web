using MVC_web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_web.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        [Authorize]
        public ActionResult Login()
        {
            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel();
            return View();
        }
    }
}
using MVC_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace MVC_web.ModelBinder
{
    public class EmployeeModelBinder : System.Web.Mvc.DefaultModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext, System.Web.Mvc.ModelBindingContext bindingContext, Type modelType)
        {
            Employee employee = new Employee();
            employee.FirstName = controllerContext.RequestContext.HttpContext.Request.Form["FName"];
            employee.LastName = controllerContext.RequestContext.HttpContext.Request.Form["LName"];
            employee.Salary = int.Parse(controllerContext.RequestContext.HttpContext.Request.Form["Salary"]);
            return employee;
        }
    }
}
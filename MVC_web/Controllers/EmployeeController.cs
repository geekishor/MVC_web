using MVC_web.ModelBinder;
using MVC_web.Models;
using MVC_web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_web.Controllers
{
    public class EmployeeController : Controller
    {
        public class Customer
        {
            public string CustomerName { get; set; }
            public string Address { get; set; }

            public override string ToString()
            {
                return this.CustomerName + "|" + this.Address;
            }
        }

        public Customer GetCustomer()
        {
            Customer c = new Customer();
            c.CustomerName = "Customer 1";
            c.Address = "Address1";
            return c;
        }

        public string GetString()
        {
            return "Hello World is old now. It’s time for wassup bro ;)";
        }


        public ActionResult Index()
        {
            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
            List<Employee> employees = empBal.GetEmployess();

            EmployeeListViewModel empListViewModel = new EmployeeListViewModel();

            List<EmployeeViewModel> employeeViewModel = new List<EmployeeViewModel>();

            foreach (Employee item in employees)
            {
                EmployeeViewModel empViewModel = new EmployeeViewModel();
                if (item.Salary > 15000)
                {
                    empViewModel.SalaryColor = "yellow";
                }
                else
                {
                    empViewModel.SalaryColor = "red";
                }
                empViewModel.EmployeeName = item.FirstName + " " + item.LastName;
                empViewModel.Salary = item.Salary.ToString("C");
                employeeViewModel.Add(empViewModel);
            }
            empListViewModel.Employees = employeeViewModel;

            return View("Index", empListViewModel);
        }

        public ActionResult AddNew()
        {
            return View("CreateEmployee", new CreateEmployeViewModel());
        }

        public ActionResult SaveEmployee(Employee e, String BtnSubmit)// public ActionResult SaveEmployee([ModelBinder(typeof(EmployeeModelBinder))]Employee e, String BtnSubmit)//public ActionResult SaveEmployee(Employee e, String BtnSubmit)
        {
            switch (BtnSubmit)
            {
                case "Save Employee":
                    if (ModelState.IsValid)
                    {

                        EmployeeBusinessLayer empBusinessLayer = new EmployeeBusinessLayer();
                        empBusinessLayer.SaveEmployee(e);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        CreateEmployeViewModel vm = new CreateEmployeViewModel();
                        vm.FirstName = e.FirstName;
                        vm.LastName = e.LastName;
                        if (e.Salary.ToString() != "")
                        {
                            vm.Salary = e.Salary.ToString();
                        }
                        else
                        {
                            vm.Salary = ModelState["Salary"].Value.AttemptedValue;
                        }
                        return View("CreateEmployee", vm);
                    }

                case "Cancel":
                    return RedirectToAction("Index");
            }

            return new EmptyResult();
        }
    }
}
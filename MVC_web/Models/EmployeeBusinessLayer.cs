using MVC_web.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_web.Models
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployess()
        {
            //List<Employee> employees = new List<Employee>();
            //Employee emp = new Employee();

            //emp.FirstName = "Kishor Bikram";
            //emp.LastName = "Oli";
            //emp.Salary = 20000;
            //employees.Add(emp);

            //emp = new Employee();
            //emp.FirstName = "michael";
            //emp.LastName = "jackson";
            //emp.Salary = 8000;
            //employees.Add(emp);

            //emp = new Employee();
            //emp.FirstName = "robert";
            //emp.LastName = " pattinson";
            //emp.Salary = 20000;
            //employees.Add(emp);

            //return employees;

            SalesERPDAL salesDal = new SalesERPDAL();
            return salesDal.Employees.ToList();
        }

        public Employee SaveEmployee(Employee e)
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            salesDal.Employees.Add(e);
            salesDal.SaveChanges();
            return e;
        }
    }
}
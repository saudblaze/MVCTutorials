using MVCIn7Days.Models;
using MVCIn7Days.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCIn7Days.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public class Customer
        {
            public string CustomerName { get; set; }
            public string Address { get; set; }
        }

        public string GetCustomer()
        {
            Customer c = new Customer();
            c.CustomerName = "Customer 1";
            c.Address = "Address1";
            //return c;

            return c.CustomerName + "|" + c.Address;
        }

        public string GetString()
        {
            return "Hello World is old now. It’s time for wassup bro ;)";
        }

        //[NonAction]
        public string SimpleMethod()
        {
            return "Hi, I am not action method";
        }

        public ActionResult GetView()
        {
            return View("MyView");
        }

        public ActionResult GetSharedView()
        {
            bool isSharedView = false;
            if (isSharedView)
            {
                return View("MyView");
            }
            else
            {
                //return View("YourView");
                return Content("YourView");
            }
        }



        ///// day 2

        //public class Employee
        //{
        //    public string FirstName { get; set; }
        //    public string LastName { get; set; }
        //    public int Salary { get; set; }
        //}

        public ActionResult GetEmployee()
        {
            //Employee emp = new Employee();
            //emp.FirstName = "Sukesh";
            //emp.LastName = "Marla";
            //emp.Salary = 20000;

            ////ViewData["Employee"] = emp;

            //ViewBag.Employee = emp;

            //return View("MyView");

            //return View("MyView");



            //Employee emp = new Employee();
            //emp.FirstName = "Sukesh";
            //emp.LastName = "Marla";
            //emp.Salary = 20000;
            ////return View("MyView", emp);


            //EmployeeViewModel vmEmp = new EmployeeViewModel();
            //vmEmp.EmployeeName = emp.FirstName + " " + emp.LastName;
            //vmEmp.Salary = emp.Salary.ToString("C");
            //if (emp.Salary > 15000)
            //{
            //    vmEmp.SalaryColor = "yellow";
            //}
            //else
            //{
            //    vmEmp.SalaryColor = "green";
            //}

            //vmEmp.UserName = "Admin";

            //return View("MyView", vmEmp);

            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel();

            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
            List<Employee> employees = empBal.GetEmployees();

            List<EmployeeViewModel>  empViewModels = new List<EmployeeViewModel>();

            foreach (Employee emp in employees)
            {
                EmployeeViewModel empViewModel = new EmployeeViewModel();
                empViewModel.EmployeeName = emp.FirstName + " " + emp.LastName;
                empViewModel.Salary = emp.Salary.ToString("C");
                if (emp.Salary > 15000)
                {
                    empViewModel.SalaryColor = "yellow";
                }
                else
                {
                    empViewModel.SalaryColor = "green";
                }
                empViewModels.Add(empViewModel);
            }
            employeeListViewModel.Employees = empViewModels;
            employeeListViewModel.UserName = "Admin";
            return View("MyView", employeeListViewModel);


        }

    }
}
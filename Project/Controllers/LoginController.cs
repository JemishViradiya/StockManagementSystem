using Assignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class LoginController : Controller
    {
        public DatabaseConnection connection { get; set; }
        public LoginController(DatabaseConnection db)
        {
            connection = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Customer model)
        {

            if (model.customer_email == "admin@gmail.com" && model.password == "admin123")
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                var customer = connection.customers.Where(c => c.customer_email == model.customer_email && c.password == model.password).FirstOrDefault();
                if (customer != null)
                {
                    HttpContext.Session.SetString("email", model.customer_email);
                    HttpContext.Session.SetInt32("customer_id", customer.customer_id);
                    HttpContext.Session.SetString("customer_name", customer.customer_name);
                    return RedirectToAction("Index", "Portfolio");
                }
                else
                {
                    ViewBag.Message = "Incorrect User and Password";
                    return View(customer);
                }
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Customer customer)
        {
            connection.customers.Add(customer);
            connection.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

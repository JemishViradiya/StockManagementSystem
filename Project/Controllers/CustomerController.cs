using Assignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class CustomerController : Controller
    {
        public DatabaseConnection connection { get; set; }
        public CustomerController(DatabaseConnection db)
        {
            connection = db;
        }
        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Buy(int id)
        {
            var stockdetails = connection.stocks.Where(s => s.stock_id == id).FirstOrDefault();
            Order order = new Order();
            
            order.stock = stockdetails;
            return View(order);
        }

        [HttpPost]
        public IActionResult Buy(Order order)
        {
            var total_value = order.quantity * order.stock.stock_price;
            var quantity = order.stock.stock_quantity;
            var updated_quantity = quantity - order.quantity;
            order.stock.stock_quantity = updated_quantity;
            
            connection.stocks.Update(order.stock);
            order.status = "Payment Pending";
            order.stock_id = order.stock.stock_id;
            order.totalAmount = total_value;
            order.customerId = (int) HttpContext.Session.GetInt32("customer_id");
            order.orderDate = System.DateTime.Now;
           
            connection.orders.Add(order);

            connection.SaveChanges();
            return RedirectToAction("Index", "Portfolio");

        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Stock");
        }
    }
}

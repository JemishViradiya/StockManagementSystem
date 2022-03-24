using Assignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class OrderController : Controller
    {
       public int quantity;
        public DatabaseConnection connection { get; set; }
        public OrderController(DatabaseConnection db)
        {
            connection = db;
        }
        public IActionResult Index()
        {
            int customer_id = (int)HttpContext.Session.GetInt32("customer_id");
            var orders = connection.orders.Where(c => c.customerId == customer_id).ToList();
            foreach(var order in orders)
            {
                order.stock = connection.stocks.Where(s => s.stock_id == order.stock_id).FirstOrDefault();
            }
            return View(orders);
        }
        [HttpGet]
        public IActionResult Payment(int id)
        {

            var order = connection.orders.Where(o => o.id == id).FirstOrDefault();
            order.stock = connection.stocks.Where(s => s.stock_id == order.stock_id).FirstOrDefault();
            return View(order);
        }

        [HttpPost]
        public IActionResult Payment(Payment payment)
        {
            payment.customer_id = (int)HttpContext.Session.GetInt32("customer_id");
            var order = connection.orders.Where(o => o.id == payment.order_id).FirstOrDefault();
            order.status = "Approved";
            
            connection.payments.Add(payment);
            connection.SaveChanges();
            Portfolio newPortfolio = new Portfolio();
            newPortfolio.client_id = (int)HttpContext.Session.GetInt32("customer_id");
            newPortfolio.portfolio_size = order.quantity;
            newPortfolio.stock_id = order.stock_id;
            return RedirectToAction("Add", "Portfolio", newPortfolio);
        }

        public IActionResult Delete(int id)
        {
            var order = connection.orders.Where(o => o.id == id).FirstOrDefault();
            connection.orders.Remove(order);
            connection.SaveChanges();
            var stock = connection.stocks.Where(s => s.stock_id == order.stock_id).FirstOrDefault();
            stock.stock_quantity = stock.stock_quantity + order.quantity;
            connection.Entry(stock).State = EntityState.Modified;
            connection.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Modify(int id)
        {
            var order = connection.orders.Where(c => c.id == id).FirstOrDefault();
            
            
            order.stock = connection.stocks.Where(s => s.stock_id == order.stock_id).FirstOrDefault();
            HttpContext.Session.SetInt32("quantity", order.quantity);
            return View(order);
        }
        [HttpPost]
        public IActionResult Modify(Order order)
        {
            order.customerId = (int)HttpContext.Session.GetInt32("customer_id");
            order.orderDate = System.DateTime.Now;
            order.totalAmount = order.quantity * order.stock.stock_price;
            order.stock_id = order.stock.stock_id;
            order.status = "Payment Pending";
            int quantity = (int)HttpContext.Session.GetInt32("quantity");
            order.stock.stock_quantity = order.stock.stock_quantity + quantity - order.quantity;
            connection.Entry(order).State = EntityState.Modified;
            connection.Entry(order.stock).State = EntityState.Modified;
            connection.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}

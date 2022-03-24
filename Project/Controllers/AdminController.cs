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
    public class AdminController : Controller
    {
        public DatabaseConnection connection { get; set; }
        public AdminController(DatabaseConnection db)
        {
            connection = db;
        }
        public IActionResult Index()
        {
            var stock = connection.stocks.ToList();

            return View(stock);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Stock stock)
        {
            connection.stocks.Add(stock);
            connection.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }
        public IActionResult Modify(int id)
        {
            var stock = connection.stocks.Where(s => s.stock_id == id).FirstOrDefault();
            return View(stock);
        }
        [HttpPost]
        public IActionResult Modify(Stock stock)
        {
            connection.Entry(stock).State = EntityState.Modified;
            connection.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var stock = connection.stocks.Where(s => s.stock_id == id).FirstOrDefault();
            ViewBag.stock_id = id;
            HttpContext.Session.SetInt32("stock_id", id);
            var portfoliolist = connection.portfolios.Where(p => p.stock_id == id).ToList();
            List<Display> model = new List<Display>();

            if (portfoliolist.Count != 0)
            {

                foreach (var item in portfoliolist)
                {
                    var customer = connection.customers.Where(c => c.customer_id == item.client_id).FirstOrDefault();
                    Display display = new Display();
                    display.customer_id = item.client_id;
                    display.quantity = item.portfolio_size;
                    display.customer = customer;
                    display.portfolio = item;
                    model.Add(display);
                }
            }
            var orders = connection.orders.Where(o => o.stock_id == id && o.status == "Payment Pending").ToList();
            var count = 0;
            if (orders.Count != 0)
            {
                foreach (var item in orders)
                {

                    foreach (var display in model)
                    {

                        if (display.customer_id == item.customerId)
                        {
                            display.pending_quantity = display.pending_quantity + item.quantity;

                        }
                        else
                        {
                            count = count + 1;
                        }
                    }
                    if (model.Count == count)
                    {
                        Display display = new Display();
                        display.customer_id = item.customerId;
                        var customer = connection.customers.Where(c => c.customer_id == item.customerId).FirstOrDefault();
                        display.customer = customer;
                        display.pending_quantity = item.quantity;
                        display.customer = customer;
                        display.order = item;
                        model.Add(display);
                    }
                }

            }
            return View(model);
        }
        public IActionResult DeleteHolding(int id)
        {
            var stock_id = (int)HttpContext.Session.GetInt32("stock_id");
            var portfolio = connection.portfolios.Where(p => p.client_id == id && p.stock_id == stock_id).FirstOrDefault();
            if(portfolio!=null)
            {
                connection.portfolios.Remove(portfolio);
                connection.SaveChanges();
            }

            var orders = connection.orders.Where(o => o.customerId == id && o.stock_id == stock_id && o.status == "Payment Pending").ToList();
            if(orders.Count !=0)
            {
                foreach(var item in orders)
                {
                    connection.orders.Remove(item);
                    connection.SaveChanges();
                }

            }
            return RedirectToAction("Delete", stock_id);
        }
        public IActionResult DeleteStock(int id)
        {
            var stock = connection.stocks.Where(s => s.stock_id == id).FirstOrDefault();
            var order = connection.orders.Where(o => o.stock_id == id).ToList();
            foreach(var item in order)
            {
                connection.orders.Remove(item);
                connection.SaveChanges();
            }
            connection.stocks.Remove(stock);
            connection.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Customer()
        {
            var customerlist = connection.customers.ToList();
            return View(customerlist);
        }

        public IActionResult Update(int id)
        {
            var customer = connection.customers.Where(c => c.customer_id == id).FirstOrDefault();
            return View(customer);

        }

        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            var customeroldata = connection.customers.Where(c => c.customer_id == customer.customer_id).FirstOrDefault();
            customer.password = customeroldata.password;
            connection.Entry(customer).State = EntityState.Modified;

            connection.SaveChanges();
            return RedirectToAction("Customer");
        }

        public IActionResult Order()
        {
            var orderlist = connection.orders.ToList();
            foreach(var item in orderlist)
            {
                item.stock = connection.stocks.Where(s => s.stock_id == item.stock_id).FirstOrDefault();
                item.customer = connection.customers.Where(c => c.customer_id == item.customerId).FirstOrDefault();
            }
            return View(orderlist);

        }
        public IActionResult ModifyOrder(int id)
        {
            var order = connection.orders.Where(o => o.id == id).FirstOrDefault();
            order.status = "Approved";
            connection.Entry(order).State = EntityState.Modified;
            Portfolio portfolio = new Portfolio();
            portfolio.client_id = order.customerId;
            portfolio.stock_id = order.stock_id;
            portfolio.portfolio_size = order.quantity;
            var check = connection.portfolios.Where(p => p.stock_id == portfolio.stock_id && p.client_id == portfolio.client_id).FirstOrDefault();
            if (check != null)
            {
                check.portfolio_size = check.portfolio_size + portfolio.portfolio_size;
                connection.Entry(check).State = EntityState.Modified;
            }
            else
            {
                connection.portfolios.Add(portfolio);
            }
            connection.SaveChanges();
            return RedirectToAction("Order");
        }
        public IActionResult DeleteOrder(int id)
        {
            var order = connection.orders.Where(o => o.id == id).FirstOrDefault();
            connection.orders.Remove(order);
            connection.SaveChanges();
            return RedirectToAction("Order");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Stock");
        }
    }
}

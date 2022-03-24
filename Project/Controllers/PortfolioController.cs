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
    public class PortfolioController : Controller
    {
        public DatabaseConnection connection { get; set; }
        public PortfolioController(DatabaseConnection db)
        {
            connection = db;
        }
        public IActionResult Index()
        {
            var customer_id = (int)HttpContext.Session.GetInt32("customer_id");

            var portfolio = connection.portfolios.Where(p => p.client_id == customer_id).ToList();

            foreach (var i in portfolio)
            {
                i.Stock = connection.stocks.Where(s => s.stock_id == i.stock_id).FirstOrDefault();
            }

            return View(portfolio);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var getDetails = connection.portfolios.Where(p => p.portfolio_id == id).FirstOrDefault();
            connection.portfolios.Remove(getDetails);
            connection.SaveChanges();
            return RedirectToAction("Index");
        }

       

        
        public IActionResult Add(Portfolio portfolio)
        {
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
            return RedirectToAction("Index");
        }
    }
}

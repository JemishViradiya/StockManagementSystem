using Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class StockController : Controller
    {
        public DatabaseConnection connection { get; set; }
        public StockController(DatabaseConnection db)
        {
            connection = db;
        }
        public IActionResult Index()
        {
            var stocklist = connection.stocks.ToList();
            return View(stocklist);
        }
    }
}

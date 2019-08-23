using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using teach03.Models;

namespace teach03.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Product myProduct = new Product
            {
                ProductID = 1,
                Name = "Mersedes",
                Description = "Cool 600 model",
                Category = "car",
                Price = 100M
            };
            ViewBag.StockLevel = 2;
            return View(myProduct);
        }
    }
}
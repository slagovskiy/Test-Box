using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using teach02.Models;

namespace teach02.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //return View(new string[] { "C#", "Language", "Tests" });
            List<string> prod = new List<string>();
            foreach (Product p in Product.GetProducts()) {
                string name = p?.Name ?? "<None>";
                decimal? price = p?.Price;
                string related = p?.Related?.Name ?? "<None>";
                prod.Add(string.Format("Name: {0}, Price: {1}, Related: {2}", name, price, related));
                prod.Add($"Name: {name}, Price: {price}, Related: {related}");
            }
            return View(prod);
        }
    }
}
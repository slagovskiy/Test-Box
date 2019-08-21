using System;
using Microsoft.AspNetCore.Mvc;
using teach01.Models;

namespace teach01.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            int h = DateTime.UtcNow.Hour;
            ViewBag.Greating = h < 12 ? "Good morning" : "Good afternoon";
            return View("MyView");
        }

        [HttpGet]
        public ViewResult InviteForm() {
            return View();
        }

        [HttpPatch]
        public ViewResult InviteForm(GuestResponse guestResponse) {
            return View();
        }
        
    }
}

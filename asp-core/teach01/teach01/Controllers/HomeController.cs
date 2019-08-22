using System;
using System.Linq;
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

        [HttpPost]
        public ViewResult InviteForm(GuestResponse guestResponse) {
            if (ModelState.IsValid)
            {
                Repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            } else
            {
                return View();
            }
        }

        public ViewResult Thanks() {
            return View();
        }

        public ViewResult ListResponses() {
            return View(Repository.Responses.Where(r => r.Name != ""));
        }
        
    }
}

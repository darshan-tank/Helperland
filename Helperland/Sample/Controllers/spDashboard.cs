using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Controllers
{
    public class spDashboard : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UpcomingService()
        {
            return View();
        }
    }
}

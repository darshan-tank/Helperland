using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Controllers
{
    public class price : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

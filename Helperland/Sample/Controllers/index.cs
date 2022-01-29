using Microsoft.AspNetCore.Mvc;
using Sample.Data;
using Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Controllers
{
    public class index : Controller
    {
        private readonly HelperlandContext _dbcontext;

        public index(HelperlandContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegistrationPost(User newSP)
        {
            _dbcontext.Users.Add(newSP);
            _dbcontext.SaveChanges();
            return RedirectToAction("index");
        }
    }
}

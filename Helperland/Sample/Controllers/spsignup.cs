using Microsoft.AspNetCore.Mvc;
using Sample.Data;
using Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Controllers
{
    public class spsignup : Controller
    {
        private readonly HelperlandContext _dbcontext;

        public spsignup(HelperlandContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IActionResult Index()
        {
            User newSP = new User();
            return View(newSP);
        }
        [HttpPost]
        public IActionResult create(User newSP)
        {
            _dbcontext.Users.Add(newSP);
            _dbcontext.SaveChanges();
            return RedirectToAction("index");
        }

    }
}

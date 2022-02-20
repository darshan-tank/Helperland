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
        public IActionResult Index(User newSP)
        {
            
            _dbcontext.Users.Add(newSP);
            var saveChange = _dbcontext.SaveChanges();
            if(saveChange > 0)
            {
                ViewData["message"] = "Registration Successfull";
                return View();
            } else
            {
                ViewData["message"] = "Something went Wrong";
                return View();
            }
            
        }

    }
}

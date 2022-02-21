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
            int count = _dbcontext.Users.Count(t => (t.Email == newSP.Email) && (t.UserTypeId == newSP.UserTypeId));
            if (count >= 1)
            {
                System.Diagnostics.Debug.WriteLine("Exist");
                ViewBag.Message = "Email already exist.";
                return View();
            }
            else
            {
                if (newSP.Password == newSP.cPassword)
                {
                    System.Diagnostics.Debug.WriteLine("same");
                    _dbcontext.Users.Add(newSP);
                    var changes = _dbcontext.SaveChanges();
                    if (changes >= 1)
                    {
                        System.Diagnostics.Debug.WriteLine("done");
                        ViewBag.Message = "Registration successfull.";
                        return View();
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("not done");
                        ViewBag.Message = "Something went wrong";
                        return View();
                    }

                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("not match");
                    return View();
                }
            }
        }

    }
}

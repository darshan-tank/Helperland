using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
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
        const string SessionEmail = "_Email";


        public index(HelperlandContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public IActionResult Index()
        {
            var t = Convert.ToString(TempData["Message"]);

            if (t != null)
            {
                ViewBag.Message = t;
            }
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult logout()
        {
            HttpContext.Session.Remove("UserEmail");
            return RedirectToAction("index");
        }
        public IActionResult forget()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User newSP)
        {
            int count = _dbcontext.Users.Count(t=>(t.Email == newSP.Email) && (t.Password == newSP.Password));
            if(count >= 1)
            {
                HttpContext.Session.SetString("UserEmail", newSP.Email);
                TempData["Message"] = "Login successfull.";
                return RedirectToAction("index");
            } else
            {
                ViewBag.Message = "Email or password are incorrect";
                return View();
            }
            
        }
        [HttpPost]
        public IActionResult ForgetPost(User newSP)
        {
            int count = _dbcontext.Users.Count(t => t.Email == newSP.Email);

            if(count >= 1)
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Helperland", "exm23391@gmail.com"));
                message.To.Add(new MailboxAddress("Helperland", newSP.Email));
                message.Subject = "Regarding Forget Password for " + newSP.Email;
                message.Body = new TextPart("plain")
                {
                    Text = "Link is valid for only 15 minutes http://localhost:63687/index/ForgetPassword"
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("exm23391@gmail.com", "visualstudio");
                    client.Send(message);
                    CookieOptions option = new CookieOptions();
                    option.Expires = DateTime.Now.AddMinutes(15);
                    Response.Cookies.Append("ForgetEmail", newSP.Email, option);
                    client.Disconnect(true);
                }
                TempData["Message"] = "Reset password link has been sent to you registered mail.";
                return RedirectToAction("index");
            } else
            {
                TempData["Message"] = "Email not exist.";
                return RedirectToAction("index");
            }
        }

        public IActionResult ForgetPassword()
        {
            if(Request.Cookies["ForgetEmail"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        [HttpPost]
        public IActionResult ForgetPassword(User newSP)
        {

            string cookieValueFromReq = Request.Cookies["ForgetEmail"];
            User u = _dbcontext.Users.Where(x => x.Email == cookieValueFromReq).FirstOrDefault();
            if(newSP.Password == newSP.cPassword)
            {
                u.Password = newSP.Password;
                _dbcontext.Attach(u);
                _dbcontext.Entry(u).Property(r => r.Password).IsModified = true;
                var changes = _dbcontext.SaveChanges();
                if(changes >= 1)
                {
                    Response.Cookies.Delete("ForgetEmail");
                    return RedirectToAction("Login");
                } else
                {
                    ViewBag.Message = "Something went wrong";
                    return View();
                }
                
            } else
            {
                return View();
            }
            
        }
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(User newSP)
        {
            int count = _dbcontext.Users.Count(t => (t.Email == newSP.Email) && (t.UserTypeId == newSP.UserTypeId));
            if(count >= 1)
            {
                ViewBag.Message = "Email already exist.";
                return View();
            } else
            {
                if (newSP.Password == newSP.cPassword)
                {
                    _dbcontext.Users.Add(newSP);
                    var changes = _dbcontext.SaveChanges();
                    if (changes >= 1)
                    {
                        ViewBag.Message = "Registration successfull.";
                        return View();
                    }
                    else
                    {
                        ViewBag.Message = "Something went wrong";
                        return View();
                    }

                }
                else
                {
                    return View();
                }
            }
        }
    }
}

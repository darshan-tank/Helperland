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
        public IActionResult LoginPost(User newSP)
        {
            int count = _dbcontext.Users.Count(t=>(t.Email == newSP.Email) && (t.Password == newSP.Password));
            if(count >= 1)
            {
                HttpContext.Session.SetString("UserEmail", newSP.Email);
                return RedirectToAction("index");
            } else
            {
                
                return RedirectToAction("index");
            }
            
        }
        [HttpPost]
        public IActionResult ForgetPost(User newSP)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Helperland", "exm23391@gmail.com"));
            message.To.Add(new MailboxAddress("Helperland", "darshntank@gmail.com"));
            message.Subject = "Regarding Forget Password for "+newSP.Email;
            message.Body = new TextPart("plain")
            {
                Text = "Link is valid for only 15 minutes http://localhost:63687/index/ForgetPassword"
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com",587,false);
                client.Authenticate("exm23391@gmail.com", "visualstudio");
                client.Send(message);
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddMinutes(15);
                Response.Cookies.Append("ForgetEmail", newSP.Email, option);
                client.Disconnect(true);
            }

            return RedirectToAction("index");
        }
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ForgetPasswordPost(User newSP)
        {
            string cookieValueFromReq = Request.Cookies["ForgetEmail"];
            User u = _dbcontext.Users.Where(x => x.Email == cookieValueFromReq).FirstOrDefault();
            u.Password = newSP.Password;
            _dbcontext.Attach(u);
            _dbcontext.Entry(u).Property(r => r.Password).IsModified = true;
            _dbcontext.SaveChanges();
            Response.Cookies.Delete("ForgetEmail");
            return RedirectToAction("Login");
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

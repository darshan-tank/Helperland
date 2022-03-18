using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Controllers
{
    public class contact : Controller
    {
        public IActionResult Index()
        {
            var t = Convert.ToString(TempData["Message"]);

            if (t != null)
            {
                ViewBag.Message = t;
            }
            return View();
        }
        public IActionResult submitQuery(String fname, String lname, String phone, String email, String subject, String message)
        {
            var msg = new MimeMessage();
            msg.From.Add(new MailboxAddress("Helperland", "exm23391@gmail.com"));
            msg.To.Add(new MailboxAddress("Helperland", "adminhelperland@yopmail.com"));
            msg.Subject = "Notification";
            msg.Body = new TextPart("plain")
            {
                Text = "Contact Details \n Name : " + fname+" "+lname+ "\n Mobile number : " + phone+ "\n Email : "+email+ "\nSubject : "+subject+"\nMessage : "+message
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("exm23391@gmail.com", "darshan@1122");
                client.Send(msg);
                client.Disconnect(true);
            }
            TempData["Message"] = "Feedback submitted.";
            return RedirectToAction("index");
            return View();
        }
    }
}

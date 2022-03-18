using MailKit.Net.Smtp;
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
    public class adminDashboard : Controller
    {
        private readonly HelperlandContext _dbcontext;


        public adminDashboard(HelperlandContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public IActionResult Index()
        {
                List<ServiceRequest> services = _dbcontext.ServiceRequests.ToList();
                for (var i = 0; i < services.Count; i++)
                {
                    if (services[i].ServiceProviderId != null)
                    {
                        services[i].ServiceProvider = _dbcontext.Users.Where(x => x.UserId == services[i].ServiceProviderId).FirstOrDefault();
                    }
                    services[i].User = _dbcontext.Users.Where(x => x.UserId == services[i].UserId).FirstOrDefault();
                    services[i].ServiceRequestaddress = _dbcontext.ServiceRequestAddresses.Where(x => x.ServiceRequestId == services[i].ServiceRequestId).FirstOrDefault();
                }
                return View(services);
            
        }
        public IActionResult userManagment()
        {
            List<User> users = _dbcontext.Users.Where(x=>x.UserTypeId != 1).ToList();
            return View(users);
        }
        public JsonResult fetchUsers()
        {
            List<User> user = _dbcontext.Users.Where(x=>x.UserTypeId!=1).ToList();
            return Json(new { Status = "success", userData = user });
        }
        public JsonResult fetchCustomers()
        {
            List<User> user = _dbcontext.Users.Where(x => (x.IsActive == true) && (x.UserTypeId == 3)).ToList();
            return Json(new { Status = "success", userData = user });
        }
        public JsonResult fetchProviders()
        {
            List<User> user = _dbcontext.Users.Where(x => (x.IsActive == true) && (x.UserTypeId == 2)).ToList();
            return Json(new { Status = "success", userData = user });
        }
        public IActionResult searchedServices(String ServiceID,String postalCode, String CustomerName, String ProviderName, String Status, DateTime fromdate, DateTime todate)
        {
            var date = fromdate.Date;
            User cust = new User();
            User pro = new User();
            if (CustomerName != null)
            {
                cust = _dbcontext.Users.Where(x => (CustomerName == null) || (x.Email == CustomerName)).FirstOrDefault();
            }
            if(ProviderName != null)
            {
                pro = _dbcontext.Users.Where(x => (ProviderName == null) || (x.Email == ProviderName)).FirstOrDefault();
            }
            
            List<ServiceRequest> srList = _dbcontext.ServiceRequests.Where(x => (ServiceID == null || x.ServiceRequestId == int.Parse(ServiceID))
            && (postalCode == null || x.ZipCode == postalCode)
            && (CustomerName == null || x.UserId == cust.UserId)
            && (ProviderName == null || x.ServiceProviderId == pro.UserId)
            && (Status == null || int.Parse(Status) == x.Status)
            && (fromdate == new DateTime(0001, 1, 1) || (x.ServiceStartDate >= fromdate && x.ServiceStartDate <= todate))
            ).ToList();
            for (var i = 0; i < srList.Count; i++)
            {
                if (srList[i].ServiceProviderId != null)
                {
                    srList[i].ServiceProvider = _dbcontext.Users.Where(x => x.UserId == srList[i].ServiceProviderId).FirstOrDefault();
                }
                srList[i].User = _dbcontext.Users.Where(x => x.UserId == srList[i].UserId).FirstOrDefault();
                srList[i].ServiceRequestaddress = _dbcontext.ServiceRequestAddresses.Where(x => x.ServiceRequestId == srList[i].ServiceRequestId).FirstOrDefault();
            }
            return View("index",srList);
        }
        public JsonResult fetchServiceDetail(String ServiceID)
        {
            ServiceRequest sr = _dbcontext.ServiceRequests.Where(x =>x.ServiceRequestId == int.Parse(ServiceID)).FirstOrDefault();
            sr.ServiceRequestaddress = _dbcontext.ServiceRequestAddresses.Where(x => x.ServiceRequestId == sr.ServiceRequestId).FirstOrDefault();
            return Json(new { Status = "success", userData = sr });
        }
        [HttpPost]
        public JsonResult saveServiceDetail(String ServiceID,DateTime date, String streetName, String houseNumber, String postalCode, String phoneNumber, String city)
        {
            var ids = int.Parse(ServiceID);
            DateTime dateData = date;
            ServiceRequest sr = _dbcontext.ServiceRequests.Where(x => x.ServiceRequestId == ids).FirstOrDefault();
            if (sr.ServiceProviderId == null)
            {
                sr.ServiceStartDate = dateData;
                sr.ModifiedDate = DateTime.Now;
                _dbcontext.Entry(sr).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ServiceRequestAddress serviceRequestAddress = _dbcontext.ServiceRequestAddresses.Where(x => x.ServiceRequestId == sr.ServiceRequestId).FirstOrDefault();
                serviceRequestAddress.AddressLine1 = streetName;
                serviceRequestAddress.AddressLine2 = houseNumber;
                serviceRequestAddress.PostalCode = postalCode;
                serviceRequestAddress.Mobile = phoneNumber;
                serviceRequestAddress.City = city;
                _dbcontext.Entry(serviceRequestAddress).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                var changes = _dbcontext.SaveChanges();
                if (changes >= 1)
                {
                    return Json(new { Status = "success" });
                }
                else
                {
                    return Json(new { Status = "fail" });
                }
            }
            else
            {
                List<ServiceRequest> srList = _dbcontext.ServiceRequests.Where(x => (x.ServiceProviderId == sr.ServiceProviderId) && (x.Status == 4)).ToList();
                var conflict = false;
                DateTime date1 = date;
                var startTime = date.ToString("hh:mm tt");
                DateTime endDate = date1.AddHours(sr.ServiceHours);
                var extra = sr.ExtraHours ?? 0.0;
                endDate = endDate.AddHours(extra);
                endDate = endDate.AddHours(1);
                var endTime = endDate.ToString("hh:mm tt");
                for (var i = 0; i < srList.Count; i++)
                {
                    if (date1 <= srList[i].ServiceStartDate && srList[i].ServiceStartDate <= endDate)
                    {
                        conflict = true;
                    }
                }
                if (conflict)
                {
                    return Json(new { Status = "Conflict", datePOST = date.ToString("dd/MM/yyyy"), startTimePOST = startTime, endTimePOST = endTime });
                }
                else
                {
                    sr.ServiceStartDate = dateData;
                    sr.ModifiedDate = DateTime.Now;
                    _dbcontext.Entry(sr).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    ServiceRequestAddress serviceRequestAddress = _dbcontext.ServiceRequestAddresses.Where(x => x.ServiceRequestId == sr.ServiceRequestId).FirstOrDefault();
                    serviceRequestAddress.AddressLine1 = streetName;
                    serviceRequestAddress.AddressLine2 = houseNumber;
                    serviceRequestAddress.PostalCode = postalCode;
                    serviceRequestAddress.Mobile = phoneNumber;
                    serviceRequestAddress.City = city;
                    _dbcontext.Entry(serviceRequestAddress).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                    var changes = _dbcontext.SaveChanges();
                    if (changes >= 1)
                    {
                        User TempSP = _dbcontext.Users.Where(x => x.UserId == sr.ServiceProviderId).FirstOrDefault();
                        var message = new MimeMessage();
                        message.From.Add(new MailboxAddress("Helperland", "exm23391@gmail.com"));
                        message.To.Add(new MailboxAddress("Helperland", TempSP.Email));
                        message.Subject = "Regarding Service : " + sr.ServiceRequestId + " Rechedule";
                        message.Body = new TextPart("plain")
                        {
                            Text = "Service Request : " + sr.ServiceRequestId + " has been rescheduled by customer. New date and time are " + date.ToString("dd/MM/yyyy") + " - " + date.ToString("hh:mm tt") + ", New address is : "+serviceRequestAddress.AddressLine1+" , "+serviceRequestAddress.AddressLine2+" , "+serviceRequestAddress.City+" , "+serviceRequestAddress.PostalCode+"."
                        };

                        using (var client = new SmtpClient())
                        {
                            client.Connect("smtp.gmail.com", 587, false);
                            client.Authenticate("exm23391@gmail.com", "darshan@1122");
                            client.Send(message);
                            client.Disconnect(true);
                        }
                        return Json(new { Status = "success" });
                    }
                    else
                    {
                        return Json(new { Status = "fail" });
                    }
                }
            }
        }
        [HttpPost]
        public JsonResult cancelService(String ServiceID)
        {
            var ids = int.Parse(ServiceID);
            String comments = "Service request cancelled by Admin.";
            ServiceRequest sr = _dbcontext.ServiceRequests.Where(x => x.ServiceRequestId == ids).FirstOrDefault();
            if (sr.ServiceProviderId == null)
            {
                sr.Comments = comments;
                sr.Status = 2;
                _dbcontext.Entry(sr).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                var changes = _dbcontext.SaveChanges();
                if (changes >= 1)
                {
                    User TempSP = _dbcontext.Users.Where(x => x.UserId == sr.UserId).FirstOrDefault();
                    var messages = new MimeMessage();
                    messages.From.Add(new MailboxAddress("Helperland", "exm23391@gmail.com"));
                    messages.To.Add(new MailboxAddress("Helperland", TempSP.Email));
                    messages.Subject = "Regarding Service : " + sr.ServiceRequestId + " Rechedule";
                    messages.Body = new TextPart("plain")
                    {
                        Text = "Service Request : " + sr.ServiceRequestId + " has been cancelled by customer. For following reason : " + comments
                    };

                    using (var client = new SmtpClient())
                    {
                        client.Connect("smtp.gmail.com", 587, false);
                        client.Authenticate("exm23391@gmail.com", "darshan@1122");
                        client.Send(messages);
                        client.Disconnect(true);
                    }
                    return Json(new { Status = "success" });
                }
                else
                {
                    return Json(new { Status = "success" });
                }
            }
            else
            {
                sr.Comments = comments;
                sr.Status = 2;
                _dbcontext.Entry(sr).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                var changes = _dbcontext.SaveChanges();
                if (changes >= 1)
                {
                    User TempSP = _dbcontext.Users.Where(x => x.UserId == sr.ServiceProviderId).FirstOrDefault();
                    var messages = new MimeMessage();
                    messages.From.Add(new MailboxAddress("Helperland", "exm23391@gmail.com"));
                    messages.To.Add(new MailboxAddress("Helperland", TempSP.Email));
                    messages.Subject = "Regarding Service : " + sr.ServiceRequestId + " Rechedule";
                    messages.Body = new TextPart("plain")
                    {
                        Text = "Service Request : " + sr.ServiceRequestId + " has been cancelled by customer. For following reason : " + comments
                    };

                    using (var client = new SmtpClient())
                    {
                        client.Connect("smtp.gmail.com", 587, false);
                        client.Authenticate("exm23391@gmail.com", "darshan@1122");
                        client.Send(messages);
                        client.Disconnect(true);
                    }
                    return Json(new { Status = "success" });
                }
                else
                {
                    return Json(new { Status = "success" });
                }
            }
        }
        [HttpPost]
        public JsonResult deactivateUser(String UserID)
        {
            User user = _dbcontext.Users.Where(x => x.UserId == int.Parse(UserID)).FirstOrDefault();
            user.IsActive = false;
            _dbcontext.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var changes = _dbcontext.SaveChanges();
            if(changes >= 1)
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Helperland", "exm23391@gmail.com"));
                message.To.Add(new MailboxAddress("Helperland", user.Email));
                message.Subject = "Regarding Account Status";
                message.Body = new TextPart("plain")
                {
                    Text = "Your account has been deactivated by the Admin."
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("exm23391@gmail.com", "darshan@1122");
                    client.Send(message);
                    client.Disconnect(true);
                }
                return Json(new { Status = "success"});
            } else
            {
                return Json(new { Status = "fail" });
            }
        }
        [HttpPost]
        public JsonResult activateUser(String UserID)
        {
            User user = _dbcontext.Users.Where(x => x.UserId == int.Parse(UserID)).FirstOrDefault();
            user.IsActive = true;
            _dbcontext.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var changes = _dbcontext.SaveChanges();
            if (changes >= 1)
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Helperland", "exm23391@gmail.com"));
                message.To.Add(new MailboxAddress("Helperland", user.Email));
                message.Subject = "Regarding Account Status";
                message.Body = new TextPart("plain")
                {
                    Text = "Your account has been activated by the Admin."
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("exm23391@gmail.com", "darshan@1122");
                    client.Send(message);
                    client.Disconnect(true);
                }
                return Json(new { Status = "success" });
            }
            else
            {
                return Json(new { Status = "fail" });
            }
        }
        public IActionResult searchedUser(String CustomerName, String UserType, String number, String postalCode, String email, DateTime fromdate, DateTime todate)
        {
            var date = fromdate.Date;
            User cust = new User();
            if (CustomerName != null)
            {
                cust = _dbcontext.Users.Where(x => (CustomerName == null) || (x.Email == CustomerName)).FirstOrDefault();
            } else if (email != null)
            {
                cust = _dbcontext.Users.Where(x => (email == null) || (x.Email == email)).FirstOrDefault();
            }

                List<User> userList = _dbcontext.Users.Where(x => (UserType == null || x.UserTypeId == int.Parse(UserType))
            && (postalCode == null || x.ZipCode == postalCode)
            && (CustomerName == null || x.UserId == cust.UserId)
            && (number == null || x.Mobile == number)
            && (email == null || x.UserId == cust.UserId)
            && (fromdate == new DateTime(0001, 1, 1) || (x.CreatedDate >= fromdate && x.CreatedDate <= todate))
            && (x.UserTypeId != 1)).ToList();
            return View("userManagment", userList);
        }
    }
}

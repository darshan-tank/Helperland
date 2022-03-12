using Microsoft.AspNetCore.Mvc;
using Sample.Data;
using Sample.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;

namespace Sample.Controllers
{
    public class spDashboard : Controller
    {
        private readonly HelperlandContext _dbcontext;

        public spDashboard(HelperlandContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UpcomingService()
        {
            var email = HttpContext.Session.GetString("UserEmail");
            User currentUser = _dbcontext.Users.Where(x => x.Email == email).FirstOrDefault();
            List<ServiceRequest> serviceRequests = _dbcontext.ServiceRequests.Where(x => (x.ServiceProviderId == currentUser.UserId) && (x.Status == 4)).ToList();
            for (var i = 0; i < serviceRequests.Count; i++)
            {
                serviceRequests[i].User = _dbcontext.Users.Where(x => x.UserId == serviceRequests[i].UserId).FirstOrDefault();
                serviceRequests[i].ServiceRequestaddress = _dbcontext.ServiceRequestAddresses.Where(x => x.ServiceRequestId == serviceRequests[i].ServiceRequestId).FirstOrDefault();
            }
            return View(serviceRequests);
        }
        public IActionResult dashboard()
        {
            var email = HttpContext.Session.GetString("UserEmail");
            User currentUser = _dbcontext.Users.Where(x => x.Email == email).FirstOrDefault();
            DateTime currentDate = DateTime.Now;
            List<ServiceRequest> newSerivces = _dbcontext.ServiceRequests.Where(x => (x.Status == 1) && (x.ZipCode == currentUser.ZipCode) && (x.ServiceStartDate >= currentDate.Date) && (x.ServiceProviderId == null)).ToList();
            for(var i = 0; i < newSerivces.Count; i++)
            {
                var count = _dbcontext.FavoriteAndBlockeds.Count(x => (x.UserId == newSerivces[i].UserId) && (x.TargetUserId == currentUser.UserId) && (x.IsBlocked == true));
                if (count >= 1)
                {
                    newSerivces[i].User = _dbcontext.Users.Where(x => x.UserId == newSerivces[i].UserId).FirstOrDefault();
                    newSerivces[i].ServiceRequestaddress = _dbcontext.ServiceRequestAddresses.Where(x => x.ServiceRequestId == newSerivces[i].ServiceRequestId).FirstOrDefault();
                    newSerivces[i].IsBlocked = true;
                } else
                {
                    newSerivces[i].User = _dbcontext.Users.Where(x => x.UserId == newSerivces[i].UserId).FirstOrDefault();
                    newSerivces[i].ServiceRequestaddress = _dbcontext.ServiceRequestAddresses.Where(x => x.ServiceRequestId == newSerivces[i].ServiceRequestId).FirstOrDefault();
                    newSerivces[i].IsBlocked = false;
                }
                
            }
            return View(newSerivces);
        }
        public IActionResult ServiceSchedule()
        {
            return View();
        }
        public IActionResult BlockCustomer()
        {
            var email = HttpContext.Session.GetString("UserEmail");
            User user = _dbcontext.Users.Where(x => x.Email == email).FirstOrDefault();
            var UniqueIDList = _dbcontext.ServiceRequests.Where(x => (x.ServiceProviderId == user.UserId) && (x.Status == 3)).Select(x=>x.UserId).Distinct().ToList();
            List<ServiceRequest> confirmList = new List<ServiceRequest>();
            for(var i = 0; i < UniqueIDList.Count; i++)
            {
                ServiceRequest sr = _dbcontext.ServiceRequests.Where(x => (x.ServiceProviderId == user.UserId) && (x.Status == 3) && (x.UserId == UniqueIDList[i])).FirstOrDefault();
                confirmList.Add(sr);
            }
            for(var j = 0; j < confirmList.Count; j++)
            {
                confirmList[j].User = _dbcontext.Users.Where(x => x.UserId == confirmList[j].UserId).FirstOrDefault();
            }
            return View(confirmList);
        }
        public IActionResult MyRating()
        {
            var email = HttpContext.Session.GetString("UserEmail");
            User user = _dbcontext.Users.Where(x => x.Email == email).FirstOrDefault();
            List<Rating> SPRating = _dbcontext.Ratings.Where(x => x.RatingTo == user.UserId).ToList();
            for(var i = 0; i < SPRating.Count; i++)
            {
                SPRating[i].RatingFromNavigation = _dbcontext.Users.Where(x => x.UserId == SPRating[i].RatingFrom).FirstOrDefault();
                SPRating[i].ServiceRequest = _dbcontext.ServiceRequests.Where(x => x.ServiceRequestId == SPRating[i].ServiceRequestId).FirstOrDefault();
                SPRating[i].Ratings = SPRating[i].Ratings / 3;
            }
            return View(SPRating);
        }
        public IActionResult ServiceHistory()
        {
            var email = HttpContext.Session.GetString("UserEmail");
            User user = _dbcontext.Users.Where(x => x.Email == email).FirstOrDefault();
            List<ServiceRequest> sr = _dbcontext.ServiceRequests.Where(x => (x.Status == 3) && (x.ServiceProviderId == user.UserId)).ToList();
            for(var i = 0; i < sr.Count; i++)
            {
                sr[i].User = _dbcontext.Users.Where(x => x.UserId == sr[i].UserId).FirstOrDefault();
                sr[i].ServiceRequestaddress = _dbcontext.ServiceRequestAddresses.Where(x => x.ServiceRequestId == sr[i].ServiceRequestId).FirstOrDefault();
            }
            return View(sr);
        }
        public IActionResult setting()
        {
            var email = HttpContext.Session.GetString("UserEmail");

            User user = _dbcontext.Users.Where(x => x.Email == email).FirstOrDefault();
            var ids = user.UserId;
            User currentUser = _dbcontext.Users.Where(x => x.UserId == ids).FirstOrDefault();
            currentUser.UserAddressforUser = _dbcontext.UserAddresses.Where(x => x.UserId == currentUser.UserId).FirstOrDefault();
            return View(currentUser);
        }
        public JsonResult GetEvents()
        {
            var email = HttpContext.Session.GetString("UserEmail");
            User user = _dbcontext.Users.Where(x => x.Email == email).FirstOrDefault();
            var sr = _dbcontext.ServiceRequests.Where(x => (x.Status == 4) && (x.ServiceProviderId == user.UserId)).ToList();
            return Json(new { data = sr, user = user });
        }
        public JsonResult getAddresses(int id)
        {
            var ids = id;
            ServiceRequestAddress sradd = _dbcontext.ServiceRequestAddresses.Where(x => x.ServiceRequestId == ids).FirstOrDefault();
            return Json(new { Status = "success", data = sradd });
        }
        public JsonResult acceptService(String serviceID)
        {
            var ServiceID = int.Parse(serviceID);
            var email = HttpContext.Session.GetString("UserEmail");

            User user = _dbcontext.Users.Where(x => x.Email == email).FirstOrDefault();
            ServiceRequest serviceRequest = _dbcontext.ServiceRequests.Where(x => x.ServiceRequestId == ServiceID).FirstOrDefault();
            DateTime date = serviceRequest.ServiceStartDate;
            DateTime endDate = date.AddHours(serviceRequest.ServiceHours);
            var extra = serviceRequest.ExtraHours ?? 0.0;
            endDate = endDate.AddHours(extra);
            endDate = endDate.AddHours(1);

            var conflictService = false;

            List<ServiceRequest> checkConflict = _dbcontext.ServiceRequests.Where(x => (x.ServiceProviderId == user.UserId) && (x.Status == 4)).ToList();

            for(var i = 0; i < checkConflict.Count; i++)
            {
                if(date <= checkConflict[i].ServiceStartDate && checkConflict[i].ServiceStartDate <= endDate)
                {
                    conflictService = true;
                }
            }

            if (conflictService)
            {
                return Json(new { Status = "Conflict" });
            } else
            {
                if (serviceRequest.ServiceProviderId == null)
                {
                    serviceRequest.ServiceProviderId = user.UserId;
                    serviceRequest.Status = 4;
                    _dbcontext.Entry(serviceRequest).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    var changes = _dbcontext.SaveChanges();
                    if (changes >= 1)
                    {

                        List<User> ServiceProviders = _dbcontext.Users.Where(x => (x.UserTypeId == 2) && (x.ZipCode == serviceRequest.ZipCode) && (x.UserId != user.UserId)).ToList();

                        for (var i = 0; i < ServiceProviders.Count; i++)
                        {
                            var message = new MimeMessage();
                            message.From.Add(new MailboxAddress("Helperland", "exm23391@gmail.com"));
                            message.To.Add(new MailboxAddress("Helperland", ServiceProviders[i].Email));
                            message.Subject = "Notification : New Service request added.";
                            message.Body = new TextPart("plain")
                            {
                                Text = "Service ID : " + serviceRequest.ServiceRequestId + " is no longer available."
                            };

                            using (var client = new SmtpClient())
                            {
                                client.Connect("smtp.gmail.com", 587, false);
                                client.Authenticate("exm23391@gmail.com", "darshan@1122");
                                client.Send(message);
                                client.Disconnect(true);
                            }
                        }

                        return Json(new { Status = "success" });
                    }
                    else
                    {
                        return Json(new { Status = "fail" });
                    }
                }
                else
                {
                    return Json(new { Status = "Error" });
                }
            }
        }
        public JsonResult fetchServiceDetails(String serviceID)
        {
            var ServiceID = int.Parse(serviceID);
            ServiceRequest serviceRequest = _dbcontext.ServiceRequests.Where(x => x.ServiceRequestId == ServiceID).FirstOrDefault();
            serviceRequest.ServiceRequestaddress = _dbcontext.ServiceRequestAddresses.Where(x => x.ServiceRequestId == serviceRequest.ServiceRequestId).FirstOrDefault();
            serviceRequest.User = _dbcontext.Users.Where(x => x.UserId == serviceRequest.UserId).FirstOrDefault();
            List<ServiceRequestExtra> serviceRequestExtras = _dbcontext.ServiceRequestExtras.Where(x => x.ServiceRequestId == serviceRequest.ServiceRequestId).ToList();
            for(var i = 0; i < serviceRequestExtras.Count; i++)
            {
                serviceRequestExtras[i].ServiceExtra = _dbcontext.ExtraServices.Where(x => x.ServiceExtraId == serviceRequestExtras[i].ServiceExtraId).FirstOrDefault();
                serviceRequest.ServiceRequestExtras.Add(serviceRequestExtras[i]);
            }
            return Json(new { Status = "success", serviceData = serviceRequest });
        }
        public JsonResult getServiceDetail(String serviceID)
        {
            var ServiceID = int.Parse(serviceID);
            ServiceRequest serviceRequest = _dbcontext.ServiceRequests.Where(x => x.ServiceRequestId == ServiceID).FirstOrDefault();
            serviceRequest.ServiceRequestaddress = _dbcontext.ServiceRequestAddresses.Where(x => x.ServiceRequestId == serviceRequest.ServiceRequestId).FirstOrDefault();
            serviceRequest.User = _dbcontext.Users.Where(x => x.UserId == serviceRequest.UserId).FirstOrDefault();
            return Json(new { Status = "success", serviceData = serviceRequest });
        }
        public JsonResult completeService(String serviceID)
        {
            var ServiceID = int.Parse(serviceID);
            ServiceRequest serviceRequest = _dbcontext.ServiceRequests.Where(x => x.ServiceRequestId == ServiceID).FirstOrDefault();
            serviceRequest.Status = 3;
            _dbcontext.Entry(serviceRequest).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var changes = _dbcontext.SaveChanges();
            if (changes >= 1)
            {
                return Json(new { Status = "success"});
            } else
            {
                return Json(new { Status = "fail" });
            }
        }
        public JsonResult cancelService(String serviceID)
        {
            var ServiceID = int.Parse(serviceID);
            ServiceRequest serviceRequest = _dbcontext.ServiceRequests.Where(x => x.ServiceRequestId == ServiceID).FirstOrDefault();
            serviceRequest.Status = 2;
            _dbcontext.Entry(serviceRequest).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
        [HttpPost]
        public JsonResult CheckBlock(int providerID, int customerID)
        {
            FavoriteAndBlocked FandB = _dbcontext.FavoriteAndBlockeds.Where(x => (x.UserId == customerID) && (x.TargetUserId == providerID)).FirstOrDefault();
            if(FandB == null)
            {
                FavoriteAndBlocked FandBNew = new FavoriteAndBlocked();
                FandBNew.UserId = customerID;
                FandBNew.TargetUserId = providerID;
                FandBNew.IsFavorite = false;
                FandBNew.IsBlocked = false;
                _dbcontext.FavoriteAndBlockeds.Add(FandBNew);
                _dbcontext.SaveChanges();
                if (FandBNew.IsBlocked == true)
                {
                    return Json(new { Status = "success" });
                }
                else
                {
                    return Json(new { Status = "fail" });
                }
            } else
            {
                if (FandB.IsBlocked == true)
                {
                    return Json(new { Status = "success" });
                }
                else
                {
                    return Json(new { Status = "fail" });
                }
            }
            
        }
        [HttpPost]
        public JsonResult BlockPro(int providerID, int customerID)
        {
            var count = _dbcontext.FavoriteAndBlockeds.Count(x => (x.UserId == customerID) && (x.TargetUserId == providerID));
            if(count >= 1)
            {
                FavoriteAndBlocked FandB = _dbcontext.FavoriteAndBlockeds.Where(x => (x.UserId == customerID) && (x.TargetUserId == providerID)).FirstOrDefault();
                FandB.IsBlocked = true;
                _dbcontext.Entry(FandB).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                var changes = _dbcontext.SaveChanges();
                if (changes >= 1)
                {
                    return Json(new { Status = "success" });
                }
                else
                {
                    return Json(new { Status = "fail" });
                }
            } else
            {
                FavoriteAndBlocked FandB = new FavoriteAndBlocked();
                FandB.UserId = customerID;
                FandB.TargetUserId = providerID;
                FandB.IsFavorite = false;
                FandB.IsBlocked = true;
                _dbcontext.FavoriteAndBlockeds.Add(FandB);
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
        }
        [HttpPost]
        public JsonResult UnblockPro(int providerID, int customerID)
        {
            FavoriteAndBlocked FandB = _dbcontext.FavoriteAndBlockeds.Where(x => (x.UserId == customerID) && (x.TargetUserId == providerID)).FirstOrDefault();
            FandB.IsBlocked = false;
            _dbcontext.Entry(FandB).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
        [HttpPost]
        public JsonResult saveDetails(String fname, String lname, String number, DateTime dob, int nationality,int gender, String avatar, String add1, String add2, String postalCode, String city)
        {
            var id = int.Parse(HttpContext.Session.GetString("UserID"));
            User updateUser = _dbcontext.Users.Where(x => x.UserId == id).FirstOrDefault();
            updateUser.FirstName = fname;
            updateUser.LastName = lname;
            updateUser.Mobile = number;
            updateUser.DateOfBirth = dob;
            updateUser.NationalityId = nationality;
            updateUser.ZipCode = postalCode;
            updateUser.Gender = gender;
            updateUser.UserProfilePicture = avatar;
            _dbcontext.Entry(updateUser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var changes = _dbcontext.SaveChanges();
            var count = _dbcontext.UserAddresses.Count(x => x.UserId == id);
            if(count >= 1)
            {
                UserAddress oldAddress = _dbcontext.UserAddresses.Where(x => x.UserId == id).FirstOrDefault();
                oldAddress.AddressLine1 = add1;
                oldAddress.AddressLine2 = add2;
                oldAddress.PostalCode = postalCode;
                oldAddress.City = city;
                _dbcontext.Entry(oldAddress).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                var changesAddress = _dbcontext.SaveChanges();
                if (changes >= 1 && changesAddress>=1)
                {
                    HttpContext.Session.SetString("UserFirstName", fname);
                    HttpContext.Session.SetString("UserLastName", lname);
                    return Json(new { Status = "success" });
                }
                else
                {
                    return Json(new { Status = "fail" });
                }
            } else
            {
                UserAddress newAddress = new UserAddress();
                newAddress.AddressLine1 = add1;
                newAddress.AddressLine2 = add2;
                newAddress.PostalCode = postalCode;
                newAddress.City = city;
                newAddress.State = city;
                newAddress.UserId = id;
                newAddress.Mobile = updateUser.Mobile;
                newAddress.Email = updateUser.Email;
                _dbcontext.UserAddresses.Add(newAddress);
                var changesAddress = _dbcontext.SaveChanges();
                if (changes >= 1 && changesAddress >= 1)
                {
                    HttpContext.Session.SetString("UserFirstName", fname);
                    HttpContext.Session.SetString("UserLastName", lname);
                    return Json(new { Status = "success" });
                }
                else
                {
                    return Json(new { Status = "fail" });
                }
            }
        }
        [HttpPost]
        public JsonResult changePassword(String oldpassword, String password)
        {
            var id = int.Parse(HttpContext.Session.GetString("UserID"));
            var count = _dbcontext.Users.Count(x => (x.UserId == id) && (x.Password == oldpassword));
            if (count >= 1)
            {
                User updateUser = _dbcontext.Users.Where(x => x.UserId == id).FirstOrDefault();
                updateUser.Password = password;
                _dbcontext.Attach(updateUser);
                _dbcontext.Entry(updateUser).Property(r => r.Password).IsModified = true;
                var changes = _dbcontext.SaveChanges();
                if (changes == 1)
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
                return Json(new { Status = "error" });
            }

        }
    }
}

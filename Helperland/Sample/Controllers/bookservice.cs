using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Sample.Data;
using Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;

namespace Sample.Controllers
{
    public class bookservice : Controller
    {
        private readonly HelperlandContext _dbcontext;
        const string SessionEmail = "_Email";


        public bookservice(HelperlandContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult code(string code)
        {
            /*int zipcode = _dbcontext.Zipcodes.Count(x => x.ZipcodeValue == code);*/
            var count = _dbcontext.Users.Count(x => (x.UserTypeId == 2) && (x.ZipCode == code));
            if (count >= 1)
            {
                HttpContext.Session.SetString("ServicePostalCode", code);
                return Json(new { Status = "success" });
            } else
            {
                return Json(new { Status = "fail" });
            }
           
        }
        [HttpPost]
        public JsonResult loginservice(User newSP)
        {
            int count = _dbcontext.Users.Count(t => (t.Email == newSP.Email) && (t.Password == newSP.Password));
            if (count >= 1)
            {
                int count1 = _dbcontext.Users.Count(t => (t.Email == newSP.Email) && (t.Password == newSP.Password) && (t.UserTypeId == 3));
                if (count1 >= 1)
                {
                    User newUser = _dbcontext.Users.Where(t => (t.Email == newSP.Email) && (t.Password == newSP.Password)).FirstOrDefault();
                    String fname = newUser.FirstName;
                    String lname = newUser.LastName;
                    HttpContext.Session.SetString("UserFirstName", fname);
                    HttpContext.Session.SetString("UserLastName", lname);
                    HttpContext.Session.SetString("UserType", newUser.UserTypeId.ToString());
                    HttpContext.Session.SetString("UserEmail", newSP.Email);
                    HttpContext.Session.SetString("UserID", newSP.UserId.ToString());
                    return Json(new { Status = "success", email = newSP.Email });
                } else
                {
                    return Json(new { Status = "wrong" });
                }
            }
            else
            {
                return Json(new { Status = "fail" });
            }

        }
        [HttpPost]
        public JsonResult addaddress(String add1, String add2, String pscode, String city, String number)
        {
            UserAddress tempadd = new UserAddress();
            tempadd.AddressLine1 = add1;
            tempadd.AddressLine2 = add2;
            tempadd.PostalCode = pscode;
            tempadd.City = city;
            tempadd.State = city;
            tempadd.Mobile = number;

            String email = HttpContext.Session.GetString("UserEmail");
            User newUser = _dbcontext.Users.Where(x => x.Email == email).FirstOrDefault();

            tempadd.UserId = newUser.UserId;
            tempadd.IsDefault = false;
            tempadd.IsDeleted = false;
            tempadd.Email = email;

            _dbcontext.UserAddresses.Add(tempadd);
            var SaveStatus = _dbcontext.SaveChanges();
            if (SaveStatus == 1)
            {
                return Json(new { Status = "success",Message = "Address Added." });
            }
            else
            {
                return Json(new { Status = "fail", Message = "Something went wrong." });
            }
        }
        [HttpPost]
        public JsonResult completeBook(String postal,String noOfBed,String noOfBath,DateTime date,String totalHrs,String extraHrs,List<String> extra,String comments,String pets,int address,String subtotal,String discount,String totalAmount,int status,String FavPro)
        {
            String postalData = postal;
            String noOfBedData = noOfBed;
            String noOfBathData = noOfBath;
            DateTime dateData = date;
            float totalHrsData = float.Parse(totalHrs);
            float extraHrsData = float.Parse(extraHrs);
            String commentsData = comments;
            String petsData = pets;
            List<String> extraData = extra;
            int addressData = address;
            bool petBit = false;
            List<ServiceRequest> newLi = _dbcontext.ServiceRequests.ToList();
            if (petsData == "true")
            {
                petBit = true;
            }
            
            String email = HttpContext.Session.GetString("UserEmail");
            User newUser = _dbcontext.Users.Where(x => x.Email == email).FirstOrDefault();
            int userID = newUser.UserId;
            decimal subtotalData = Convert.ToDecimal(subtotal);
            decimal discountData = Convert.ToDecimal(discount);
            decimal totalAmountData = Convert.ToDecimal(totalAmount);
            ServiceRequest sr = new ServiceRequest();
            sr.UserId = userID;
            sr.ServiceId = 0;
            sr.ServiceStartDate = dateData;
            sr.Status = status;

            UserAddress userAdd = _dbcontext.UserAddresses.Where(x => x.AddressId == addressData).FirstOrDefault();

            sr.ZipCode = userAdd.PostalCode;
            if (FavPro != null && FavPro != "undefined")
            {
                sr.ServiceProviderId = int.Parse(FavPro);
                sr.Status = 4;
            }
            sr.ServiceHourlyRate = 2034;
            sr.ServiceHours = totalHrsData;
            sr.ExtraHours = extraHrsData;
            sr.SubTotal = subtotalData;
            sr.Discount = discountData;
            sr.TotalCost = totalAmountData;
            sr.Comments = commentsData;
            sr.HasPets = petBit;
            sr.CreatedDate = DateTime.Now;
            sr.ModifiedDate = DateTime.Now;
            _dbcontext.ServiceRequests.Add(sr);
            var saveChange1 = _dbcontext.SaveChanges();

            int Id = sr.ServiceRequestId;

            var ServiceID = _dbcontext.ServiceRequests.OrderByDescending(p => p.ServiceId).FirstOrDefault().ServiceRequestId;
            

            

            ServiceRequestAddress srAddress = new ServiceRequestAddress();
            srAddress.ServiceRequestId = (Id);
            srAddress.AddressLine1 = userAdd.AddressLine1;
            srAddress.AddressLine2 = userAdd.AddressLine2;
            srAddress.City = userAdd.City;
            srAddress.State = userAdd.State;
            srAddress.PostalCode = userAdd.PostalCode;
            srAddress.Mobile = userAdd.Mobile;
            srAddress.Email = userAdd.Email;

            _dbcontext.ServiceRequestAddresses.Add(srAddress);
            var saveChange2 = _dbcontext.SaveChanges();


            

            if(extraData.Count >= 1)
            {
                if(extraData[0] != null)
                {
                    string[] strTemp = extraData[0].Split(new char[] { ',', }, StringSplitOptions.RemoveEmptyEntries);

                    for (var i = 0; i < strTemp.Length; i++)
                    {
                        ExtraService serviceExtraIDObj = _dbcontext.ExtraServices.Where(x => x.ServiceExtraName == strTemp[i]).FirstOrDefault();
                        var ServiceExtraID = serviceExtraIDObj.ServiceExtraId;
                        ServiceRequestExtra srExtra = new ServiceRequestExtra();
                        srExtra.ServiceRequestId = (Id);
                        srExtra.ServiceExtraId = ServiceExtraID;
                        _dbcontext.ServiceRequestExtras.Add(srExtra);
                        _dbcontext.SaveChanges();
                    }
                }
            }

            if(saveChange1 >= 1 && saveChange2 >= 1)
            {
                HttpContext.Session.Remove("ServicePostalCode");

                if(sr.ServiceProviderId == null)
                {
                    List<User> ServiceProviders = _dbcontext.Users.Where(x => (x.UserTypeId == 2) && (x.ZipCode == postalData)).ToList();
                    for(var i = 0; i < ServiceProviders.Count; i++)
                    {
                        var count = _dbcontext.FavoriteAndBlockeds.Count(x => (x.UserId == userID) && (x.TargetUserId == ServiceProviders[i].UserId) && (x.IsBlocked == true));
                        if(count >= 1)
                        {
                            
                        } else
                        {
                            var message = new MimeMessage();
                            message.From.Add(new MailboxAddress("Helperland", "exm23391@gmail.com"));
                            message.To.Add(new MailboxAddress("Helperland", ServiceProviders[i].Email));
                            message.Subject = "Notification : New Service request added.";
                            message.Body = new TextPart("plain")
                            {
                                Text = "New service request added for " + postalData + " this postalcode. Service Id is : " + Id
                            };

                            using (var client = new SmtpClient())
                            {
                                client.Connect("smtp.gmail.com", 587, false);
                                client.Authenticate("exm23391@gmail.com", "darshan@1122");
                                client.Send(message);
                                client.Disconnect(true);
                            }
                        }
                    }
                } else
                {
                    User SelectedServiceProvider = _dbcontext.Users.Where(x => (x.UserId == sr.ServiceProviderId) && (x.UserTypeId == 2)).FirstOrDefault();
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("Helperland", "exm23391@gmail.com"));
                    message.To.Add(new MailboxAddress("Helperland", SelectedServiceProvider.Email));
                    message.Subject = "Notification : New Service request added.";
                    message.Body = new TextPart("plain")
                    {
                        Text = "New service request added for " + postalData + " this postalcode. Service Id is : " + Id
                    };

                    using (var client = new SmtpClient())
                    {
                        client.Connect("smtp.gmail.com", 587, false);
                        client.Authenticate("exm23391@gmail.com", "darshan@1122");
                        client.Send(message);
                        client.Disconnect(true);
                    }
                }

                

                return Json(new { Status = "success"});
            } else
            {
                return Json(new { Status = "fail"});
            }
        }
        public IActionResult getaddress()
        {
            var ServicePostalCode = HttpContext.Session.GetString("ServicePostalCode");
            System.Threading.Thread.Sleep(2000);
            String email = HttpContext.Session.GetString("UserEmail");
            User newUser = _dbcontext.Users.Where(x=>x.Email == email).FirstOrDefault();
            List<UserAddress> address = _dbcontext.UserAddresses.Where(x=>(x.UserId == newUser.UserId) && (x.PostalCode == ServicePostalCode) && (x.IsDeleted == false)).ToList();
            return View(address);
            
        }
        public IActionResult getFavPros()
        {
            System.Threading.Thread.Sleep(2000);
            String email = HttpContext.Session.GetString("UserEmail");
            User newUser = _dbcontext.Users.Where(x => x.Email == email).FirstOrDefault();
            List<FavoriteAndBlocked> FandB = _dbcontext.FavoriteAndBlockeds.Where(x => (x.UserId == newUser.UserId) && (x.IsFavorite == true) && (x.IsBlocked == false)).ToList();
            for (var i = 0; i < FandB.Count; i++)
            {
                FandB[i].User = _dbcontext.Users.Where(x => x.UserId == FandB[i].UserId).FirstOrDefault();
                FandB[i].TargetUser = _dbcontext.Users.Where(x => x.UserId == FandB[i].TargetUserId).FirstOrDefault();
            }
            return View(FandB);

        }
    }
}

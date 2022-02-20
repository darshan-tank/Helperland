﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Data;
using Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            System.Diagnostics.Debug.WriteLine(HttpContext.Session.GetString("UserEmail"));
            return View();
        }
        [HttpPost]
        public JsonResult code(string code)
        {
            string name = string.Format("{0}", code); ;
            if (code == "555666")
            {
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
                    HttpContext.Session.SetString("UserEmail", newSP.Email);
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
                return Json(new { Status = "success" });
            }
            else
            {
                return Json(new { Status = "fail" });
            }
        }
        [HttpPost]
        public JsonResult completeBook(String postal,String noOfBed,String noOfBath,DateTime date,String totalHrs,String extraHrs,List<String> extra,String comments,String pets,int address,String subtotal,String discount,String totalAmount)
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
            int id = newLi.Last().ServiceRequestId;
            System.Diagnostics.Debug.WriteLine(id);
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

            UserAddress userAdd = _dbcontext.UserAddresses.Where(x => x.AddressId == addressData).FirstOrDefault();

            sr.ZipCode = userAdd.PostalCode;
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

            var ServiceID = _dbcontext.ServiceRequests.OrderByDescending(p => p.ServiceId).FirstOrDefault().ServiceRequestId;
            

            

            ServiceRequestAddress srAddress = new ServiceRequestAddress();
            srAddress.ServiceRequestId = (id + 1);
            srAddress.AddressLine1 = userAdd.AddressLine1;
            srAddress.AddressLine2 = userAdd.AddressLine2;
            srAddress.City = userAdd.City;
            srAddress.State = userAdd.State;
            srAddress.PostalCode = userAdd.PostalCode;
            srAddress.Mobile = userAdd.Mobile;
            srAddress.Email = userAdd.Email;

            _dbcontext.ServiceRequestAddresses.Add(srAddress);
            var saveChange2 = _dbcontext.SaveChanges();


            string[] strTemp = extraData[0].Split(new char[] { ',', }, StringSplitOptions.RemoveEmptyEntries);
            System.Diagnostics.Debug.WriteLine(strTemp.Length);

            for(var i = 0; i < strTemp.Length; i++)
            {
                ExtraService serviceExtraIDObj = _dbcontext.ExtraServices.Where(x => x.ServiceExtraName == strTemp[i]).FirstOrDefault();
                var ServiceExtraID = serviceExtraIDObj.ServiceExtraId;
                System.Diagnostics.Debug.WriteLine(ServiceExtraID);
                ServiceRequestExtra srExtra = new ServiceRequestExtra();
                srExtra.ServiceRequestId = (id + 1);
                srExtra.ServiceExtraId = ServiceExtraID;
                _dbcontext.ServiceRequestExtras.Add(srExtra);
                _dbcontext.SaveChanges();
            }

            if(saveChange1 >= 1 && saveChange2 >= 1)
            {
                return Json(new { Status = "success" });
            } else
            {
                return Json(new { Status = "fail" });
            }
        }
        public IActionResult getaddress()
        {
            System.Threading.Thread.Sleep(2000);
            String email = HttpContext.Session.GetString("UserEmail");
            User newUser = _dbcontext.Users.Where(x=>x.Email == email).FirstOrDefault();
            List<UserAddress> address = _dbcontext.UserAddresses.Where(x=>x.UserId == newUser.UserId).ToList();
            System.Diagnostics.Debug.WriteLine(address);
            return View(address);
            
        }
    }
}
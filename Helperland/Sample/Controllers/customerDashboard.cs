using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using Sample.Models;
using Sample.Data;

namespace Sample.Controllers
{
    public class customerDashboard : Controller
    {
        private readonly HelperlandContext _dbcontext;
        const string SessionEmail = "_Email";


        public customerDashboard(HelperlandContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public IActionResult Index()
        {
            var t = Convert.ToString(TempData["Type"]);

            if (t != null)
            {
                ViewBag.Message = t;
            }
            return View();
        }
        public IActionResult ServiceHistory()
        {
            var id = HttpContext.Session.GetString("UserID");
            var email = HttpContext.Session.GetString("UserEmail");

            User user = _dbcontext.Users.Where(x => x.Email == email).FirstOrDefault();
            List<ServiceRequest> sr = _dbcontext.ServiceRequests.Where(x => (x.Status == 2) && (x.UserId == user.UserId)).ToList();
                for (var i = 0; i < sr.Count; i++)
            {
                sr[i].ServiceProvider = _dbcontext.Users.Where(x => x.UserId == sr[i].ServiceProviderId).FirstOrDefault();

                if (sr[i].ServiceProvider != null)
                {
                    List<Rating> countRating = _dbcontext.Ratings.Where(x => x.RatingTo == sr[i].ServiceProviderId).ToList();

                    var totalRating = 0.0;

                    for (var j = 0; j < countRating.Count; j++)
                    {
                        totalRating = totalRating + Convert.ToDouble(countRating[j].Ratings);
                    }

                    var finalRate = totalRating / countRating.Count;

                    finalRate = finalRate / 3;

                    sr[i].ServiceProvider.Ratings = finalRate;
                }
            }
            return View(sr);
        }
        public IActionResult setting()
        {
            var id = int.Parse(HttpContext.Session.GetString("UserID"));
            User currentUser = _dbcontext.Users.Where(x=>x.UserId == id).FirstOrDefault();
            return View(currentUser);
        }
        public IActionResult CurrentService()
        {
            
            var id = HttpContext.Session.GetString("UserID");

            var email = HttpContext.Session.GetString("UserEmail");
                
            User user = _dbcontext.Users.Where(x => x.Email == email).FirstOrDefault();
            List <ServiceRequest> sr = _dbcontext.ServiceRequests.Where(x => (x.Status == 1) && (x.UserId == user.UserId)).ToList();
            for (var i = 0; i < sr.Count; i++)
            {
                sr[i].ServiceProvider = _dbcontext.Users.Where(x => x.UserId == sr[i].ServiceProviderId).FirstOrDefault();

                if(sr[i].ServiceProvider != null)
                {
                    List<Rating> countRating = _dbcontext.Ratings.Where(x => x.RatingTo == sr[i].ServiceProviderId).ToList();

                    var totalRating = 0.0;

                    for (var j = 0; j < countRating.Count; j++)
                    {
                        totalRating = totalRating + Convert.ToDouble(countRating[j].Ratings);
                    }

                    var finalRate = totalRating / countRating.Count;

                    finalRate = finalRate / 3;

                    sr[i].ServiceProvider.Ratings = finalRate;
                }
            }
                return View(sr);
        }
        public IActionResult ServiceSchedule()
        {
            List<ServiceRequest> sr = _dbcontext.ServiceRequests.Where(x => x.Status == 1).ToList();
            return View(sr);
        }
        public IActionResult FavoritePro()
        {
            var id = HttpContext.Session.GetString("UserID");
            List<FavoriteAndBlocked> FandB = _dbcontext.FavoriteAndBlockeds.Where(x => (x.UserId == int.Parse(id)) && (x.IsFavorite == true)).ToList();

            for(var i=0;i< FandB.Count; i++)
            {
                FandB[i].User = _dbcontext.Users.Where(x => x.UserId == FandB[i].UserId).FirstOrDefault();
                FandB[i].TargetUser = _dbcontext.Users.Where(x => x.UserId == FandB[i].TargetUserId).FirstOrDefault();

                List<Rating> countRating = _dbcontext.Ratings.Where(x => x.RatingTo == FandB[i].TargetUser.UserId).ToList();

                var totalRating = 0.0;

                for (var j = 0; j < countRating.Count; j++)
                {
                    totalRating = totalRating + Convert.ToDouble(countRating[j].Ratings);
                }

                var finalRate = totalRating / countRating.Count;

                finalRate = finalRate / 3;

                var countTotalService = _dbcontext.Ratings.Count(x => x.RatingTo == FandB[i].TargetUser.UserId);
                FandB[i].TargetUser.totalCleanings = countTotalService;

                FandB[i].TargetUser.Ratings = finalRate;
            }

            return View(FandB);
        }
        public IActionResult getaddress()
        {
            System.Threading.Thread.Sleep(2000);
            String email = HttpContext.Session.GetString("UserEmail");
            User newUser = _dbcontext.Users.Where(x => x.Email == email).FirstOrDefault();
            List<UserAddress> address = _dbcontext.UserAddresses.Where(x => x.UserId == newUser.UserId).ToList();
            return View(address);
        }
        public JsonResult GetEvents()
        {
            var email = HttpContext.Session.GetString("UserEmail");
            User user = _dbcontext.Users.Where(x => x.Email == email).FirstOrDefault();
            var sr = _dbcontext.ServiceRequests.Where(x => (x.Status == 1) && (x.UserId == user.UserId)).ToList();
            return Json(new { data = sr, user = user });
        }
        public JsonResult getAddresses(int id)
        {
            var ids = id;
            ServiceRequestAddress sradd = _dbcontext.ServiceRequestAddresses.Where(x => x.ServiceRequestId == ids).FirstOrDefault();
            return Json(new { Status = "success", data = sradd });
        }
        [HttpPost]
        public JsonResult reschedule(int id, DateTime date)
        {
            var ids = id;
            DateTime dateData = date;
            ServiceRequest sr = _dbcontext.ServiceRequests.Where(x => x.ServiceRequestId == ids).FirstOrDefault();
            sr.ServiceStartDate = dateData;
            sr.ModifiedDate = DateTime.Now;
            _dbcontext.Entry(sr).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var changes = _dbcontext.SaveChanges();
            if (changes >= 1)
            {
                return Json(new { Status = "success"});
            }
            else
            {
                return Json(new { Status = "success"});
            }
        }
        [HttpPost]
        public JsonResult cancel(int id,String message)
        {
            var ids = id;
            String comments = message;
            ServiceRequest sr = _dbcontext.ServiceRequests.Where(x => x.ServiceRequestId == ids).FirstOrDefault();
            sr.Comments = comments;
            sr.Status = 2;
            _dbcontext.Entry(sr).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var changes = _dbcontext.SaveChanges();
            if (changes >= 1)
            {
                return Json(new { Status = "success" });
            }
            else
            {
                return Json(new { Status = "success" });
            }
        }
        [HttpPost]
        public JsonResult checkFavorite(int providerID,int customerID)
        {
            var serviceProviderID = providerID;
            var CustomerID = customerID;
            var count = _dbcontext.FavoriteAndBlockeds.Count(x => (x.UserId == CustomerID) && (x.TargetUserId == serviceProviderID) && (x.IsFavorite == true));
            if (count >= 1)
            {
                return Json(new { Status = "success" });
            }
            else
            {
                return Json(new { Status = "fail" });
            }
        }
        [HttpPost]
        public JsonResult getProviderName(int providerID,int serviceRequestID)
        {
            User provider = _dbcontext.Users.Where(x => x.UserId == providerID).FirstOrDefault();

            int count = _dbcontext.Ratings.Count(x => x.ServiceRequestId == serviceRequestID);

            List<Rating> countRating = _dbcontext.Ratings.Where(x => x.RatingTo == providerID).ToList();

            var totalRating = 0.0;

            for(var i=0; i < countRating.Count; i++)
            {
                totalRating = totalRating + Convert.ToDouble(countRating[i].Ratings);
            }

            var finalRate = totalRating / countRating.Count;

            finalRate = finalRate / 3;

            if (count >= 1)
            {
                Rating rating = _dbcontext.Ratings.Where(x => x.ServiceRequestId == serviceRequestID).FirstOrDefault();
                return Json(new { Status = "success", user = provider, ratingSubmitted = 1, ratingObject = rating, finalrate = finalRate });
            } else
            {
                return Json(new { Status = "fail", user = provider, ratingSubmitted = 0, finalrate = finalRate });
            }

            
        }
        [HttpPost]
        public JsonResult RatingSubmit(int providerID,int customerID,Double ratingOnTime,Double ratingFriendly,Double ratingQuality,int serviceRequestID, String comments)
        {
            decimal RatingOnTime = Convert.ToDecimal(ratingOnTime);
            decimal RatingFriendly = Convert.ToDecimal(ratingFriendly);
            decimal RatingQuality = Convert.ToDecimal(ratingQuality);

            Rating rating= new Rating();
            rating.ServiceRequestId = serviceRequestID;
            rating.RatingFrom = customerID;
            rating.RatingTo = providerID;
            rating.OnTimeArrival = RatingOnTime;
            rating.Friendly = RatingFriendly;
            rating.QualityOfService = RatingQuality;
            rating.Comments = comments;
            rating.RatingDate = DateTime.Now;

            var ratingFinal = RatingOnTime + RatingFriendly + RatingQuality;

            rating.Ratings = ratingFinal;

            _dbcontext.Ratings.Add(rating);
            var saveChange1 = _dbcontext.SaveChanges();
            if(saveChange1 >= 1)
            {
                return Json(new { Status = "success" });
            }
            else
            {
                return Json(new { Status = "fail" });
            }
        }

        [HttpPost]
        public JsonResult Favorite(String type,int providerID,int customerID)
        {
            int count = _dbcontext.FavoriteAndBlockeds.Count(x => (x.UserId == customerID) && (x.TargetUserId == providerID));
            if (count >= 1)
            {
                if (type == "favorite")
                {
                    FavoriteAndBlocked FandB = _dbcontext.FavoriteAndBlockeds.Where(x => (x.UserId == customerID) && (x.TargetUserId == providerID)).FirstOrDefault();
                    FandB.IsFavorite = true;
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
                else
                {
                    FavoriteAndBlocked FandB = _dbcontext.FavoriteAndBlockeds.Where(x => (x.UserId == customerID) && (x.TargetUserId == providerID)).FirstOrDefault();
                    FandB.IsFavorite = false;
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
            }
            else
            {
                if (type == "favorite")
                {
                    FavoriteAndBlocked FandB = new FavoriteAndBlocked();
                    FandB.IsFavorite = true;
                    FandB.IsBlocked = false;
                    User provider = _dbcontext.Users.Where(x => x.UserId == providerID).FirstOrDefault();
                    User customer = _dbcontext.Users.Where(x => x.UserId == customerID).FirstOrDefault();
                    FandB.UserId = customerID;
                    FandB.TargetUserId = providerID;
                    _dbcontext.Add(FandB);
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
                    FandB.IsFavorite = false;
                    _dbcontext.Add(FandB);
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
        }

        [HttpPost]
        public JsonResult CheckBlock(int providerID, int customerID)
        {
            FavoriteAndBlocked FandB = _dbcontext.FavoriteAndBlockeds.Where(x => (x.UserId == customerID) && (x.TargetUserId == providerID)).FirstOrDefault();
            if(FandB.IsBlocked == true)
            {
                return Json(new { Status = "success" });
            }
            else
            {
                return Json(new { Status = "fail" });
            }
        }
        [HttpPost]
        public JsonResult removeFav(int providerID, int customerID)
        {
            FavoriteAndBlocked FandB = _dbcontext.FavoriteAndBlockeds.Where(x => (x.UserId == customerID) && (x.TargetUserId == providerID)).FirstOrDefault();
            FandB.IsFavorite = false;
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
        public JsonResult BlockPro(int providerID, int customerID)
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
        public JsonResult fetchAddress(int addressID)
        {
            UserAddress userAddress = _dbcontext.UserAddresses.Where(x => x.AddressId == addressID).FirstOrDefault();
            var count = _dbcontext.UserAddresses.Count(x => x.AddressId == addressID);
            if (count >= 1)
            {
                return Json(new { Status = "success", addressObject = userAddress });
            }
            else
            {
                return Json(new { Status = "fail" });
            }
        }
        [HttpPost]
        public JsonResult updateAddress(int addressID,String streetName,String houseNumber, String postalCode, String phoneNumber)
        {
            UserAddress userAddress = _dbcontext.UserAddresses.Where(x => x.AddressId == addressID).FirstOrDefault();
            userAddress.AddressLine1 = streetName;
            userAddress.AddressLine2 = houseNumber;
            userAddress.PostalCode = postalCode;
            userAddress.Mobile = phoneNumber;
            _dbcontext.Entry(userAddress).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var count = _dbcontext.SaveChanges();
            if (count >= 1)
            {
                return Json(new { Status = "success"});
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
                return Json(new { Status = "success", Message = "Address Added." });
            }
            else
            {
                return Json(new { Status = "fail", Message = "Something went wrong." });
            }
        }
        [HttpPost]
        public JsonResult deleteAddress(int addressID)
        {
            UserAddress userAddress = _dbcontext.UserAddresses.Where(x => x.AddressId == addressID).FirstOrDefault();
            _dbcontext.Entry(userAddress).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            var changes = _dbcontext.SaveChanges();
            if (changes == 1)
            {
                return Json(new { Status = "success"});
            }
            else
            {
                return Json(new { Status = "fail"});
            }
        }
        [HttpPost]
        public JsonResult saveDetails(String fname, String lname, String number, DateTime dob, int language)
        {
            var id = int.Parse(HttpContext.Session.GetString("UserID"));
            User updateUser = _dbcontext.Users.Where(x => x.UserId == id).FirstOrDefault();
            updateUser.FirstName = fname;
            updateUser.LastName = lname;
            updateUser.Mobile = number;
            updateUser.DateOfBirth = dob;
            updateUser.LanguageId = language;
            _dbcontext.Entry(updateUser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
        [HttpPost]
        public JsonResult changePassword(String oldpassword, String password)
        {
            var id = int.Parse(HttpContext.Session.GetString("UserID"));
            var count = _dbcontext.Users.Count(x => (x.UserId == id) && (x.Password == oldpassword));
            if(count >= 1)
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
            } else
            {
                return Json(new { Status = "error" });
            }
            
        }
    }
}

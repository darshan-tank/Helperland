﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Controllers
{
    public class faq : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

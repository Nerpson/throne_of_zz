﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZZThrone.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListHouse()
        {
            return View();
        }

        public ActionResult NewHouse()
        {
            return View();
        }
    }
}
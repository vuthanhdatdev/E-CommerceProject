﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Data;

namespace OnlineSeller.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult _TopMenu()
        {
            var model = new MenuData().ListByGroupId(2);
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult _MainMenu()
        {
            var model = new MenuData().ListByGroupId(1);
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult Menu_Left()
        {
            var model = new MenuData().ListByGroupId(2);
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult _Footer()
        {
            var model = new FooterData().GetFooter();
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult Slide()
        {
            var model = new SlideData().GetSlides();
            return PartialView(model);
        }
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
﻿using System.Web.Mvc;

namespace Notus.Hub.Controllers
{
    public class VisualizeController : Controller
    {
        // GET: Visualize
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            return PartialView();
        }

        public ActionResult TreeMap()
        {
            return PartialView();
        }
    }
}
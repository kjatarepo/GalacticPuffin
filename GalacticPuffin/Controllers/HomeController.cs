using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GalacticPuffin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult About()
        //{
        //   // ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        public ActionResult Contact()
        {
          //  ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Privacy()
        {
            ViewBag.Title = "Privacy";
            ViewBag.Message = "Privacy";

            return View();
        }
        public ActionResult Service()
        {
            ViewBag.Title = "Service";
            ViewBag.Message = "Service";

            return View();
        }

        public ActionResult App()
        {
            ViewBag.Title = "App";
            ViewBag.Message = "App";

            return View();
        }
    }
}
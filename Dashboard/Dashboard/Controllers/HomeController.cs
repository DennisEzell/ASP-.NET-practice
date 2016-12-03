using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Dashboard.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string apiUrl = "https://api.github.com/events";
            var webRequest = (HttpWebRequest)WebRequest.Create(apiUrl);
            webRequest.UserAgent = "application/vnd.github.v3+json";
            Stream webResponse = webRequest.GetResponse().GetResponseStream();

            using (StreamReader read = new StreamReader(webResponse))
            {
                while (read.Peek() >= 0)
                {
                    System.Diagnostics.Debug.WriteLine(read.ReadLine());
                }
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
using Dashboard.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
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
            //Have to include a valide UserAgent https://developer.github.com/v3/#user-agent-required
            webRequest.UserAgent = "DennisEzell";
            webRequest.Accept = "application/vnd.github.v3+json";
            StreamReader read = new StreamReader(webRequest.GetResponse().GetResponseStream());
            var gitEvents = JsonConvert.DeserializeObject<IEnumerable<GitEvent>>(read.ReadToEnd());

            return View(gitEvents);

            //WebRequest req = WebRequest.CreateHttp(apiUrl);
            //var req = WebRequest.CreateHttp(apiUrl);
            //req.UserAgent = "DennisEzell";
            //req.Accept = "application/vnd.github.v3+json";

            //var resp = req.GetResponse();

            //WebClient client = new WebClient();
            ////client.BaseAddress = apiUrl;
            ////client.Headers["User Agent"] = "DennisEzell";
            //client.Headers.Add(HttpRequestHeader.UserAgent, "DennisEzell");
            //client.Headers.Add(HttpRequestHeader.Accept, "application/vnd.github.v3+json");

            //string resp = client.DownloadString(apiUrl);


            //return View();
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
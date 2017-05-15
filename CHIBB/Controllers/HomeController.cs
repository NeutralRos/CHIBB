using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace CHIBB.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Layout"] = GetLayout();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            ViewData["Layout"] = GetLayout();
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            ViewData["Layout"] = GetLayout();

            return View();
        }


        public IActionResult Error()
        {
            ViewData["Layout"] = GetLayout();
            return View();
        }

        public string GetLayout()
        {
            var name = HttpContext.Session.GetString("Username");
            var layout = "_Layout";
            if (name != string.Empty)
            {
                layout = "_LayoutLogin";
            }
            return layout;
        }
    }
}

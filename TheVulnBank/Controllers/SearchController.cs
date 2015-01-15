using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheVulnBank.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Index(string q)
        {
            ViewData["Search"] = q;
            return View();
        }
    }
}

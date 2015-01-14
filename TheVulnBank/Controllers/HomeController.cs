using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheVulnBank.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewData["IsAuthenticated"] = isAuthenticated;
            ViewData["UserId"] = userId;
            return View();
        }

    }
}

using System.Web.Mvc;

namespace TheVulnBank.Controllers
{
    public class SearchController : BaseController
    {
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

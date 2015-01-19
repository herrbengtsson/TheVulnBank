using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using TheVulnBank.Models.Data;
using TheVulnBank.Models.View;
using TheVulnBank.Repositories;

namespace TheVulnBank.Controllers
{
    public class SearchController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Index(string q, string noOfItems = "5")
        {
            // Blind SQLI
            var result = new SearchResult() { Items = new List<SearchItem>() };

            int noOfItemsParsed;

            if (!int.TryParse(noOfItems, out noOfItemsParsed))
            {
                ViewData["Error"] = "noOfItems must be an integer";
                //return View(result);
            }
            
            if (!string.IsNullOrEmpty(q) && q.Length > 0)
            {
                try
                {
                    result.Items = GetSearchRepo().Search(q, noOfItems);
                }
                catch (System.Exception)
                {
                    // ...
                }
            }

            return View(result);
        }

        private SearchRepository GetSearchRepo()
        {
            return new SearchRepository(new SqlConnection(ConfigurationManager.ConnectionStrings["TheVulnBankDB"].ConnectionString));
        }
    }
}

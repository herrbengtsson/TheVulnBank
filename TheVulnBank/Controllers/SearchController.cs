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
        [ValidateInput(false)]
        public ActionResult Index(string q)
        {
            ArticleRepository articleRepository = new ArticleRepository(new SqlConnection(ConfigurationManager.ConnectionStrings["TheVulnBankDB"].ConnectionString));
            List<Article> articles = articleRepository.SearchArticles(q);
            return View(new Search
            {
                Query = q,
                Articles = articles,
            });
        }
    }
}

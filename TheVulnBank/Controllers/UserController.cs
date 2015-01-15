using System.Configuration;
using System.Data.SqlServerCe;
using System.Web.Mvc;
using TheVulnBank.Filters;
using TheVulnBank.Models.Data;
using TheVulnBank.Repositories;

namespace TheVulnBank.Controllers
{
    public class UserController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            if (!isAuthenticated)
            {
                return RedirectToAction("Index", "Login");
            }
            return ShowUser(userId);
        }

        [HttpGet]
        [RequireLoginFilter]
        public ActionResult ShowUser(int id)
        {
            UserRepository userRepository = new UserRepository(new SqlCeConnection(ConfigurationManager.ConnectionStrings["TheVulnBankDBContext"].ConnectionString));
            User user = userRepository.GetUser(id);
            return View("ShowUser", user);
        }

        [HttpGet]
        [RequireLoginFilter]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [RequireLoginFilter]
        public ActionResult ChangePassword(string password)
        {
            UserRepository userRepository = new UserRepository(new SqlCeConnection(ConfigurationManager.ConnectionStrings["TheVulnBankDBContext"].ConnectionString));
            userRepository.ChangePassword(userId, password);

            TempData.Add("Message", "Password changed");
            return RedirectToAction("Index", "User");
        }

    }
}

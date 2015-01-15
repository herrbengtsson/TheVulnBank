using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheVulnBank.Repositories;
using TheVulnBank.Models.Data;
using System.Configuration;
using System.Data.SqlServerCe;

namespace TheVulnBank.Controllers
{
    public class UserController : BaseController
    {
        //
        // GET: /User/
        [HttpGet]
        public ActionResult Index()
        {
            if (!isAuthenticated)
            {
                return RedirectToAction("Index", "Login");
            }
            return ShowUser(userId);
        }

        //
        // GET: /User/ShowUser/{userId}
        [HttpGet]
        public ActionResult ShowUser(int id)
        {
            if (!isAuthenticated)
            {
                return RedirectToAction("Index", "Login");
            }
            UserRepository userRepository = new UserRepository(new SqlCeConnection(ConfigurationManager.ConnectionStrings["TheVulnBankDBContext"].ConnectionString));
            User user = userRepository.GetUser(id);
            return View("ShowUser", user);
        }

        //
        // GET: /User/
        [HttpGet]
        public ActionResult ChangePassword()
        {
            if (!isAuthenticated)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        //
        // GET: /User/
        [HttpPost]
        public ActionResult ChangePassword(string password)
        {
            if (!isAuthenticated)
            {
                return RedirectToAction("Index", "Login");
            }

            UserRepository userRepository = new UserRepository(new SqlCeConnection(ConfigurationManager.ConnectionStrings["TheVulnBankDBContext"].ConnectionString));
            userRepository.ChangePassword(userId, password);

            TempData.Add("Message", "Password changed");
            return RedirectToAction("Index", "User");
        }

    }
}

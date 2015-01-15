using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TheVulnBank.Repositories;
using TheVulnBank.Models.Data;

namespace TheVulnBank.Controllers
{
    public class LoginController : BaseController
    {
        //
        // GET: /Login/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //
        // POST: /Login/
        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            //TempData.Add("Message", "POST");
            UserRepository userRepository = new UserRepository(new SqlCeConnection(ConfigurationManager.ConnectionStrings["TheVulnBankDBContext"].ConnectionString));
            if (userRepository.UserExists(username)) 
            {
                if (userRepository.LoginUser(username, password)) 
                {
                    User user = userRepository.GetUser(username);

                    TempData.Add("Message", "Logged in: " + user.Username);
                    Session["Authorized"] = true;

                    HttpCookie authCookie = new HttpCookie("Authorized");
                    authCookie.Value = true.ToString();
                    authCookie.Expires = DateTime.Now.AddHours(8);
                    Response.SetCookie(authCookie);

                    HttpCookie userIdCookie = new HttpCookie("UserId");
                    userIdCookie.Value = user.Id.ToString();
                    userIdCookie.Expires = DateTime.Now.AddHours(8);
                    Response.SetCookie(userIdCookie);

                    return View();
                }
                else 
                {
                    TempData.Add("Message", "Password does not match");

                    HttpCookie cookie = new HttpCookie("Authorized");
                    cookie.Value = false.ToString();
                    cookie.Expires = DateTime.Now.AddHours(8);
                    Response.SetCookie(cookie);

                    return View();
                }
            }
            else 
            {
                TempData.Add("Message", "User does not exist");

                HttpCookie cookie = new HttpCookie("Authorized");
                cookie.Value = false.ToString();
                cookie.Expires = DateTime.Now.AddHours(8);
                Response.SetCookie(cookie);

                return View();
            }
        }

    }
}

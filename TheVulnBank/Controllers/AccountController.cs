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

namespace TheVulnBank.Controllers
{
    public class AccountController : BaseController
    {
        //
        // GET: /Account/
        [HttpGet]
        public ActionResult Index()
        {
            if (isAuthenticated)
            {
                AccountRepository accountRepository = new AccountRepository(new SqlCeConnection(ConfigurationManager.ConnectionStrings["TheVulnBankDBContext"].ConnectionString));
                List<Account> accounts = accountRepository.ListAccounts(userId);
                return View(accounts);
            }
            return RedirectToAction("Index", "Login");
        }

        //
        // GET: /Account/Transfers/{id}
        [HttpGet]
        public ActionResult Transfers(int accountId)
        {
            if (isAuthenticated)
            {
                AccountRepository accountRepository = new AccountRepository(new SqlCeConnection(ConfigurationManager.ConnectionStrings["TheVulnBankDBContext"].ConnectionString));
                List<Transfer> transfers = accountRepository.ListTransfers(accountId);
                return View(transfers);
            }
            return RedirectToAction("Index", "Login");
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

    public class Account
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public double Amount { get; set; }
    }

    public class Transfer
    {
        public int Id { get; set; }
        public int SendAccId { get; set; }
        public int RecAccId { get; set; }
        public double Amount { get; set; }
        public string Message { get; set; }
    }

    public class AccountRepository
    {

        private SqlCeConnection connection;

        public AccountRepository(SqlCeConnection connection) 
        {
            this.connection = connection;
        }

        public List<Account> ListAccounts(int userId)
        {
            List<Account> result = new List<Account>();
            //using(this.connection) 
            {
                SqlCeCommand command = new SqlCeCommand("SELECT Id, Amount FROM Accounts WHERE UserId='" + userId + "';", this.connection);
                this.connection.Open();
                SqlCeDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Account
                    {
                        Id = reader.GetInt32(0),
                        Amount = reader.GetDouble(1),
                    });
                }
                reader.Close();
                this.connection.Close();
            }
            return result;
        }

        public List<Transfer> ListTransfers(int accountId)
        {
            List<Transfer> result = new List<Transfer>();
            //using(this.connection) 
            {
                SqlCeCommand command = new SqlCeCommand("SELECT Id, SendAccId, RecAccId, Amount, Message FROM Transfers WHERE SendAccId='" + accountId + "' OR RecAccId='" + accountId + "';", this.connection);
                this.connection.Open();
                SqlCeDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Transfer
                    {
                        Id = reader.GetInt32(0),
                        SendAccId = reader.GetInt32(1),
                        RecAccId = reader.GetInt32(2),
                        Amount = reader.GetDouble(3),
                        Message = reader.GetString(4),
                    });
                }
                reader.Close();
                this.connection.Close();
            }
            return result;
        }

        public void AddTransfers(int sendAccId, int recAccId, double amount, string message)
        {
            //using(this.connection) 
            {
                SqlCeCommand command = new SqlCeCommand("INSERT INTO Transfers (SendAccId, RecAccId, Amount, Message) VALUES (" + sendAccId + ", " + recAccId +  ", " + amount + ", '" + message + "');", this.connection);
                this.connection.Open();
                command.ExecuteNonQuery();
                this.connection.Close();
            }
        }

    }
}

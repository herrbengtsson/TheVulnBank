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
using TheVulnBank.Models.Data;
using TheVulnBank.Repositories;

namespace TheVulnBank.Controllers
{
    public class AccountController : BaseController
    {
        //
        // GET: /Account/
        [HttpGet]
        public ActionResult Index()
        {
            if (!isAuthenticated)
            {
                return RedirectToAction("Index", "Login");
            }

            AccountRepository accountRepository = new AccountRepository(new SqlCeConnection(ConfigurationManager.ConnectionStrings["TheVulnBankDBContext"].ConnectionString));
            List<Account> accounts = accountRepository.ListAccounts(userId);
            return View(accounts);
        }

        //
        // GET: /Account/Transfers/{id}
        [HttpGet]
        public ActionResult Transfers(int accountId)
        {
            if (!isAuthenticated)
            {
                return RedirectToAction("Index", "Login");
            }

            AccountRepository accountRepository = new AccountRepository(new SqlCeConnection(ConfigurationManager.ConnectionStrings["TheVulnBankDBContext"].ConnectionString));
            List<Transfer> transfers = accountRepository.ListTransfers(accountId);
            return View(new TheVulnBank.Models.View.Account
            {
                Transfers = transfers,
            });
        }

        //
        // GET: /Account/Transfer/
        [HttpGet]
        [ValidateInput(false)]
        public ActionResult Transfer()
        {
            if (!isAuthenticated)
            {
                return RedirectToAction("Index", "Login");
            }

            AccountRepository accountRepository = new AccountRepository(new SqlCeConnection(ConfigurationManager.ConnectionStrings["TheVulnBankDBContext"].ConnectionString));
            List<Account> fromAccounts = accountRepository.ListAccounts(userId);
            List<Account> toAccounts = accountRepository.ListAllAccounts();

            return View(new TheVulnBank.Models.View.Transfer
            {
                FromAccounts = fromAccounts,
                ToAccounts = toAccounts,
            });
        }

        //
        // GET: /Account/Transfer/
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Transfer(int fromAccountId, int toAccountId, double amount, string message)
        {
            if (!isAuthenticated)
            {
                return RedirectToAction("Index", "Login");
            }

            AccountRepository accountRepository = new AccountRepository(new SqlCeConnection(ConfigurationManager.ConnectionStrings["TheVulnBankDBContext"].ConnectionString));
            accountRepository.AddTransfer(fromAccountId, toAccountId, amount, message);


            return RedirectToAction("Transfers", "Account", new { accountId = fromAccountId });
        }
    }
}

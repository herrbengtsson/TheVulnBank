using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlServerCe;
using System.Web.Mvc;
using TheVulnBank.Filters;
using TheVulnBank.Models.Data;
using TheVulnBank.Repositories;

namespace TheVulnBank.Controllers
{
    public class AccountController : BaseController
    {
        [HttpGet]
        [RequireLoginFilter]
        public ActionResult Index()
        {
            AccountRepository accountRepository = new AccountRepository(new SqlCeConnection(ConfigurationManager.ConnectionStrings["TheVulnBankDBContext"].ConnectionString));
            List<Account> accounts = accountRepository.ListAccounts(userId);
            return View(accounts);
        }

        [HttpGet]
        [RequireLoginFilter]
        public ActionResult Transfers(int id)
        {
            AccountRepository accountRepository = new AccountRepository(new SqlCeConnection(ConfigurationManager.ConnectionStrings["TheVulnBankDBContext"].ConnectionString));
            List<Account> accounts = accountRepository.ListAllAccounts();
            List<Transfer> transfers = accountRepository.ListTransfers(id);
            return View(new TheVulnBank.Models.View.Account
            {
                Accounts = accounts,
                Transfers = transfers,
            });
        }

        [HttpGet]
        [ValidateInput(false)]
        [RequireLoginFilter]
        public ActionResult Transfer()
        {
            AccountRepository accountRepository = new AccountRepository(new SqlCeConnection(ConfigurationManager.ConnectionStrings["TheVulnBankDBContext"].ConnectionString));
            List<Account> fromAccounts = accountRepository.ListAccounts(userId);
            List<Account> toAccounts = accountRepository.ListAllAccounts();

            return View(new TheVulnBank.Models.View.Transfer
            {
                FromAccounts = fromAccounts,
                ToAccounts = toAccounts,
            });
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Transfer(int fromAccountId, int toAccountId, double amount, string message)
        {
            AccountRepository accountRepository = new AccountRepository(new SqlCeConnection(ConfigurationManager.ConnectionStrings["TheVulnBankDBContext"].ConnectionString));
            accountRepository.AddTransfer(fromAccountId, toAccountId, amount, message);

            return RedirectToAction("Transfers", "Account", new { accountId = fromAccountId });
        }
    }
}

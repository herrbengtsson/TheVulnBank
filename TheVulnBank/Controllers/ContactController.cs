using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheVulnBank.Filters;
using TheVulnBank.Models.Data;
using TheVulnBank.Models.View;

namespace TheVulnBank.Controllers
{
    public class ContactController : BaseController
    {
        //
        // GET: /Contact/

        public ActionResult Index()
        {
            var questions = new Questions() { Items = new List<Question>() };
            return View(questions);
        }

        [HttpPost]
        [RequireLoginFilter]
        public ActionResult Index(string q)
        {

            var questions = new Questions() { Items = new List<Question>() };

            if (!string.IsNullOrEmpty(q))
            {
                questions.Items.Add(new Question() { AgentId = 123, Answer = "Ett bra svar.", Text = q, UserId = 123 });
            }

            return View(questions);
        }

        private void AddQuestion() { }

        private void GetQuestions() { }

    }
}

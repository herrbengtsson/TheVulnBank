using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TheVulnBank.Controllers
{
    public class BaseController : Controller
    {
        protected bool isAuthenticated = false;
        protected int userId = 0;

        protected override void Initialize(RequestContext requestContext) 
        {
            base.Initialize(requestContext);
            var request = requestContext.HttpContext.Request;

            if (request.Cookies["Authorized"] != null)
            {
                bool cookieAuthValue;
                if (bool.TryParse(request.Cookies["Authorized"].Value, out cookieAuthValue))
                {
                    isAuthenticated = cookieAuthValue;
                }

                if (isAuthenticated)
                {
                    userId = int.Parse(request.Cookies["UserId"].Value);
                }
            }

            //string cookieName = FormsAuthentication.FormsCookieName;
            //HttpCookie authCookie = request.Cookies[cookieName];
            //FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            //userData = authTicket.UserData;
        }

    }
}

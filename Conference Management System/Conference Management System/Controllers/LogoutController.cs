using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using System.Data.Linq;
using Conference_Management_System.Repositories;
using Conference_Management_System.Models;

namespace Conference_Management_System.Controllers
{
    public class LogoutController : Controller
    {
        public ActionResult Logout()
        {
            try
            {
                Response.Cookies["user"]["username"] = null;
                Response.Cookies["user"]["id"] = null;
                Response.Cookies["user"]["role"] = null;
                Response.Cookies["user"].Expires = DateTime.Now.Subtract(TimeSpan.FromDays(2));

                String toRedirect = "/Login/FindUserBy";
                Response.Redirect(toRedirect);
                return null;
            }
            catch (Exception)
            {
                String toRedirect = "/Login/FindUserBy";
                Response.Redirect(toRedirect);
                return null;
            }
        }
    }
}

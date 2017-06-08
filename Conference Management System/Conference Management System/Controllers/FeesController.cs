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
    public class FeesController : Controller
    {
        public ActionResult Pay()
        {
            using (var context = new CMS())
            {
                try
                {
                    int userId = Int32.Parse(Request.Cookies["user"]["id"]);
                    var usersRepo = new AbstractCrudRepo<int, User>(context);
                    var conferencesRepo = new AbstractCrudRepo<int, Conference>(context);

                    User user = usersRepo.FindBy(u => u.Id == userId).First();
                    List<Conference> conferences = conferencesRepo.FindAll().ToList();

                    ViewBag.loggedUserRole = user.Role.ToString();
                    return View(conferences);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                return null;
            }
        }

        [ActionName("Pay"), HttpPost]
        public ActionResult PayPost()
        {
            try
            {
                using (var context = new CMS())
                {
                    int userId = Int32.Parse(Request.Cookies["user"]["id"]);
                    int conferenceId = Int32.Parse(Request.Form["conferenceId"]);

                    var usersRepo = new AbstractCrudRepo<int, User>(context);
                    var conferencesRepo = new AbstractCrudRepo<int, Conference>(context);
                    var feeRepo = new AbstractCrudRepo<int, Fee>(context);

                    User user = usersRepo.FindBy(u => u.Id == userId).First();
                    Conference conference = conferencesRepo.FindBy(c => c.Id == conferenceId).First();
                    Fee fee = null;
                    var fees = feeRepo.FindBy(f => f.User.Id == userId && f.Conference.Id == conferenceId).ToList();
<<<<<<< HEAD

                    if (fees.Count() != 0)

                        if (fees.Count != 0)
                            fee = fees.First();
                    if (fee != null)

=======
                    if (fees.Count() != 0)
                        fee = fees.First();
                    if(fee != null)
>>>>>>> 85e76d7e35321816d4cf4b0fa0a5878abf2e7321
                    {
                        TempData["notice"] = "You already paid the fee for conference " + fees.First().Conference.Name;
                    }
                    else
                    {
                        if (user.Role.CompareTo(Role.AUTHOR) == 0)
                        {
                            fee = new Fee(FeeType.AUTHOR_FEE, user, conference);
                        }
                        else
                        {
                            fee = new Fee(FeeType.LISTENER_FEE, user, conference);
                        }

                        feeRepo.Add(fee);
                        feeRepo.Save();
                        TempData["notice"] = "Succes! The fee for conference " + fee.Conference.Name + " is paid";
                    }
                    Response.Redirect("/Fees/Pay");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

    }
}

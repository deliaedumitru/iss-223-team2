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
    public class ProposalsController : Controller
    {
        private bool HasPermission()
        {
            return Helpers.DoesUserHaveRoles(Request, new Role[] { Role.PCM });
        }

        public ActionResult Bid()
        {
            if (!HasPermission())
                return View("~/Views/Shared/Forbidden.cshtml");
            using (var context = new CMS())
            {
                int? userId = Helpers.GetUserId(Request);

                var submissionsRepo = new AbstractCrudRepo<int, Submission>(context);
                var usersRepo = new AbstractCrudRepo<int, User>(context);
                List<Submission> submisions = submissionsRepo.FindAll().ToList();
                foreach (Submission submission in submisions)
                {
                    submission.Authors = submission.Authors.ToList();
                    //doar bid-urile user-ului logat
                    submission.Bids = submission.Bids.Where(b => b.Reviewer.Id == userId).ToList();
                }
                return View(submisions);
            }
        }

        [ActionName("Bid"), HttpPost]
        public ActionResult Save()
        {
            if (!HasPermission())
                return View("~/Views/Shared/Forbidden.cshtml");
            using (var context = new CMS())
            {
                int? userId = Helpers.GetUserId(Request);
                var usersRepo = new AbstractCrudRepo<int, User>(context);
                var submissionsRepo = new AbstractCrudRepo<int, Submission>(context);
                var bidsRepo = new AbstractCrudRepo<int, Bid>(context);
                List<Submission> submisions = submissionsRepo.FindAll().ToList();

                foreach (Submission submission in submisions)
                {
                    submission.Authors = submission.Authors.ToList();
                    String value = Request.Form[submission.Id.ToString()];
                    if (value != null)
                    {
                        Bid bid = new Models.Bid(-1, (BidValues)System.Enum.Parse(typeof(BidValues), value));
                        bid.Reviewer = usersRepo.FindBy(u => u.Id == userId).First();
                        //nu exista bid salvat pt submission de la userul logat
                        if (submission.Bids.Where(b => b.Reviewer.Id == userId).ToList().Count == 0)
                        {
                            submission.Bids.Add(bid);
                        } //exista bid salvat, si acum trebuie modificata valoarea
                        else
                        {
                            submission.Bids.Where(b => b.Reviewer.Id == userId).First().Value = (BidValues)System.Enum.Parse(typeof(BidValues), value);
                        }
                        submissionsRepo.Update(submission);
                        submissionsRepo.Save();
                    }
                }

                return View(submisions);
            }

        }
    }
}
    

using Conference_Management_System.Models;
using Conference_Management_System.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Conference_Management_System.Controllers
{
    public class AssignProposalsController : Controller
    {
       
        public AssignProposalsController() { }


        [HttpGet]
        public ActionResult GetAllBids()
        {
            List<Bid> bids;
            List<Submission> submissions;
            using (var context = new CMS())
            {
                var bidsRepo = new AbstractCrudRepo<int, Bid>(context);
                var submissionRepo = new AbstractCrudRepo<int, Submission>(context);

                // get all the submissions and bids
                submissions = submissionRepo.FindAll().ToList();
                bids = bidsRepo.FindAll().ToList();

                //put the bids in the submissions
                foreach (Submission submission in submissions)
                {
                    submission.Bids = submission.Bids.ToList();
                    foreach (Bid bid in submission.Bids)
                    {
                        bid.Reviewer = bid.Reviewer;
                    }
                    submission.Reviewers = submission.Reviewers.ToList();
                }
            }

            return View(submissions);
        }

        [HttpGet]
        public ActionResult Add(int reviewerId, int submissionId)
        {
            
            List<Submission> submissions;
            using (var context = new CMS())
            {
                var submissionRepo = new AbstractCrudRepo<int, Submission>(context);
                var userRepo = new AbstractCrudRepo<int, User>(context);
                User reviewer = null ;
                foreach(User user in userRepo.FindAll().ToList())
                {
                    if (user.Id == reviewerId)
                        reviewer = user;
                }

                Func<Submission, bool> findById = delegate (Submission s)
                 { return s.Id == submissionId; };
                submissions = submissionRepo.FindAll().ToList();
                foreach(Submission sub in submissions)
                {
                    if(sub.Id == submissionId)
                    {
                        List<User> reviewers = sub.Reviewers.ToList();
                        reviewers.Add(reviewer);
                        sub.Reviewers = reviewers;
                        submissionRepo.Update(sub);
                        submissionRepo.Save();
                    }                 
                }
            }

            return RedirectToAction("GetAllBids");
        }

        [HttpGet]
        public ActionResult Delete(int reviewerId, int submissionId)
        {

            List<Submission> submissions;
            using (var context = new CMS())
            {
                var submissionRepo = new AbstractCrudRepo<int, Submission>(context);
                var userRepo = new AbstractCrudRepo<int, User>(context);
                User reviewer = null;
                foreach (User user in userRepo.FindAll().ToList())
                {
                    if (user.Id == reviewerId)
                        reviewer = user;
                }

                Func<Submission, bool> findById = delegate (Submission s)
                { return s.Id == submissionId; };
                submissions = submissionRepo.FindAll().ToList();
                foreach (Submission sub in submissions)
                {
                    if (sub.Id == submissionId)
                    {
                        List<User> reviewers = sub.Reviewers.ToList();
                        reviewers.Remove(reviewer);
                        sub.Reviewers = reviewers;
                        submissionRepo.Update(sub);
                        submissionRepo.Save();
                    }
                }
            }

            return RedirectToAction("GetAllBids");
        }

    }
}
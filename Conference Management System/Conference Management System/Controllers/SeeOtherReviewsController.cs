using Conference_Management_System.Models;
using Conference_Management_System.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Conference_Management_System.Controllers
{
    public class SeeOtherReviewsController : Controller
    {
        // GET: SeeOtherReviews
        public ActionResult Index()
        {
            return View();
        }

        [ActionName("PaperList"), HttpGet]
        public ActionResult GetPapers()
        {
            List<Submission> submissions = new List<Submission>();
            using (var context = new CMS())
            {
                int? userId = Helpers.GetUserId(Request);
                var qualifierRepo = new AbstractCrudRepo<int, Qualifier>(context);
                var submissionRepo = new AbstractCrudRepo<int, Submission>(context);

                List<Qualifier> myqualifiers = qualifierRepo.FindBy(q => q.Reviewer.Id == userId).ToList();

                foreach (Qualifier qualifier in myqualifiers)
                {
                    submissions.AddRange(submissionRepo.FindBy(sub => sub.Id == qualifier.Paper.Id));
                }

            }
            return View(submissions);
        }

        [HttpGet]
        public ActionResult GetReviewsForPaper(int paperId)
        {

            List<Recommendation> recommendations = new List<Recommendation>();

            using (var context = new CMS())
            {
                try
                { 
                    int? userId = Helpers.GetUserId(Request);
                    ViewBag.userId = userId;
                    var recommendationRepo = new AbstractCrudRepo<int, Recommendation>(context);

                    recommendations = recommendationRepo.FindBy(rec => rec.SubmissionId == paperId).ToList();
                    recommendations = recommendations.Where(r => r.ReviewerId != userId).ToList();
                    foreach (Recommendation r in recommendations)
                    {
                        r.Rewiever = r.Rewiever;
                    }

                    var commentsRepo = new AbstractCrudRepo<int, Comment>(context);
                    List<Comment> comments = commentsRepo.FindBy(comm => comm.Submission.Id == paperId).ToList();
                    foreach (Comment c in comments)
                    {
                        c.Reviewer = c.Reviewer;
                    }
                    ViewBag.comments = comments;

                    return View(recommendations);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Response.Redirect("/Shared/Error");
                }
            }
            return null;
        }

    }
}
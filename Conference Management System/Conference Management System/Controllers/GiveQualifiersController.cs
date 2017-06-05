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
    public class GiveQualifiersController : Controller
    {
        public ActionResult Proposals()
        {
            using (var context = new CMS())
            {
                int userId = Int32.Parse(Request.Cookies["user"]["id"]);
                var usersRepo = new AbstractCrudRepo<int, User>(context);
                var submissionsRepo = new AbstractCrudRepo<int, Submission>(context);

                User user = usersRepo.FindBy(u => u.Id == userId).First();

                List<Submission> submissions = submissionsRepo.FindAll().ToList();
                List<Submission> assignedSubmissions = new List<Submission>();
                foreach (var submission in submissions)
                {

                    foreach (var reviewer in submission.Reviewers)
                    {
                        if (reviewer.Id == userId)
                        {
                            //doar qualifier-ul dat de userul logat
                            submission.Qualifiers = submission.Qualifiers.Where(b => b.Reviewer.Id == userId).ToList();
                            //doar recommendation-ul dat de userul logat
                            submission.Recommendations = submission.Recommendations.Where(r => r.Rewiever.Id == userId).ToList();

                            assignedSubmissions.Add(submission);
                        }
                    }
                }

                ViewBag.userId = userId;
                return View(assignedSubmissions);
            }
        }

        public void UpdateQualifier(CMS context, int submissionId, int userId, String value)
        {
            var submissionsRepo = new AbstractCrudRepo<int, Submission>(context);
            Submission submission = submissionsRepo.FindBy(s => s.Id == submissionId).First();
            bool updated = false;
            foreach (var qualifier in submission.Qualifiers)
            {
                if (qualifier.Reviewer.Id == userId)
                {
                    //exista deja un qualifier acordat de userul logat, deci trebuie sa se faca update
                    submission.Qualifiers.Where(b => b.Reviewer.Id == userId).First().Value = (QualifierValues)System.Enum.Parse(typeof(QualifierValues), value);
                    updated = true;
                }
            }

            if (updated == false)
            {
                //nu exista un qualifier anterior acordat de userul logat, deci facem add
                var usersRepo = new AbstractCrudRepo<int, User>(context);
                User user = usersRepo.FindBy(u => u.Id == userId).First();

                Qualifier qualifier = new Qualifier(-1, user, submission, (QualifierValues)System.Enum.Parse(typeof(QualifierValues), value));
                submission.Qualifiers.Add(qualifier);

            }

            submissionsRepo.Update(submission);
            submissionsRepo.Save();
        }

        public void UpdateRecommendation(CMS context, int submissionId, int userId, String value)
        {
            var submissionsRepo = new AbstractCrudRepo<int, Submission>(context);
            Submission submission = submissionsRepo.FindBy(s => s.Id == submissionId).First();

            if (value == null || value.CompareTo("") == 0)
            {
                List<Recommendation> recomendations = submission.Recommendations.Where(b => b.Rewiever.Id == userId).ToList();
                if (recomendations.Count != 0)
                {
                    var recommendationRepo = new AbstractCrudRepo<int, Recommendation>(context);
                    recommendationRepo.Delete(recomendations.First().Id);
                    recommendationRepo.Save();

                    //trebuie stearsa recomandarea anterioara
                    submission.Recommendations.Remove(recomendations.First());
                    submissionsRepo.Update(submission);
                    submissionsRepo.Save();
                }
            }
            else
            {
                bool updated = false;
                foreach (var recommendation in submission.Recommendations)
                {
                    if (recommendation.Rewiever.Id == userId)
                    {
                        //exista deja un recommendation acordat de userul logat, deci trebuie sa se faca update
                        submission.Recommendations.Where(b => b.Rewiever.Id == userId).First().Text = value;
                        updated = true;
                    }
                }

                if (updated == false)
                {
                    //nu exista un recommendation anterior acordat de userul logat, deci facem add
                    var usersRepo = new AbstractCrudRepo<int, User>(context);
                    User user = usersRepo.FindBy(u => u.Id == userId).First();

                    Recommendation recommendation = new Recommendation(-1, value, user, submission);
                    submission.Recommendations.Add(recommendation);

                }

                submissionsRepo.Update(submission);
                submissionsRepo.Save();
            }
        }


        [ActionName("Proposals"), HttpPost]
        public ActionResult UpdateQualifier()
        {
            using (var context = new CMS())
            {
                int userId = Int32.Parse(Request.Cookies["user"]["id"]);
                int reviewerId = Int32.Parse(Request.Form["userId"]);

                if(userId != reviewerId)
                {
                    throw new Exception("The request was not made by the logged in user!");
                }
                String value = Request.Form["qualifierValue"];
                int submissionId = Int32.Parse(Request.Form["submissionId"]);

                UpdateQualifier(context, submissionId, userId, value);

                String recommendation = Request.Form["recommendation"];
                UpdateRecommendation(context, submissionId, userId, recommendation);

                Response.Redirect("/GiveQualifiers/Proposals");
                return null;
            }
        }
    }
}

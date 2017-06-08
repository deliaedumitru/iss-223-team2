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
    public class CommentsController : Controller
    {
        private bool HasPermission()
        {
            return Helpers.DoesUserHaveRoles(Request, new Role[] { Role.PCM });
        }
        [HttpPost]
        public ActionResult Post()
        {
            if (!HasPermission())
                return View("~/Views/Shared/Forbidden.cshtml");
            using (var context = new CMS())
            {
                try
                {
                    int? loggedUserId = Helpers.GetUserId(Request);

                    var usersRepo = new AbstractCrudRepo<int, User>(context);
                    var commentsRepo = new AbstractCrudRepo<int, Comment>(context);

                    int userId = Int32.Parse(Request.Form["idUser"]);
                    if (userId != loggedUserId)
                    {
                        throw new Exception("Not logged in!");
                    }
                    int submissionId = Int32.Parse(Request.Form["idSubmission"]);
                    String text = Request.Form["content"];


                    var submissionRepo = new AbstractCrudRepo<int, Submission>(context);

                    User reviewer = usersRepo.FindBy(u => u.Id == userId).First();
                    Submission submission = submissionRepo.FindBy(s => s.Id == submissionId).First();

                    Comment comment = new Comment(-1, text, DateTime.Now, reviewer, submission);
                    commentsRepo.Add(comment);
                    commentsRepo.Save();

                    Response.Redirect("/SeeOtherReviews/GetReviewsForPaper?paperId=" + submissionId);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Response.Redirect("/Shared/Error");
                }
            }
            return View();
        }
    }
}

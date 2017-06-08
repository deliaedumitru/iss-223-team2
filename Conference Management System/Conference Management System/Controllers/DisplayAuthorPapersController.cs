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
    public class DisplayAuthorPapersController : Controller
    {
        public void openPaper(String submissionTitle)
        {
            try
            {
                int userId = Int32.Parse(Request.Cookies["user"]["id"]);
                string pdfPath = Server.MapPath("~/Submissions/" + submissionTitle + userId.ToString() + ".pdf");
                WebClient client = new WebClient();
                Byte[] buffer = client.DownloadData(pdfPath);
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", buffer.Length.ToString());
                Response.BinaryWrite(buffer);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Response.Redirect("/Shared/Error");
            }
        }


        [HttpGet]
        public ActionResult Papers()
        {
            try
            {
                int userId = Int32.Parse(Request.Cookies["user"]["id"]);
                List<Submission> submissionsAuthor = new List<Submission>();
                using (var context = new CMS())
                {
                    var submissionsRepo = new AbstractCrudRepo<int, Submission>(context);               
                    var allSubmissions = submissionsRepo.FindAll().ToList();

                    foreach (Submission submission in allSubmissions)
                    {
                        foreach (User author in submission.Authors)
                            if (author.Id == userId)
                            {
                                submissionsAuthor.Add(submission);
                                break;
                            }
                    }
                }

                return View(submissionsAuthor);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Response.Redirect("/Shared/Error");
            }
            return null;
        }

        // GET: DisplayAuthorPapers
        public ActionResult Index()
        {
            return View();
        }
    }
}
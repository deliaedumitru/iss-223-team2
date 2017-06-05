using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Conference_Management_System.Models;
using Conference_Management_System.Repositories;

namespace Conference_Management_System.Controllers
{
    public class SubmitProposalController : Controller
    {
        [HttpGet]
        public ActionResult Submit()
        {
            return View();
        }

        public void AddProposal(Submission submission)
        {
            using (var context = new CMS())
            {
                try
                {
                    var userRepository = new AbstractCrudRepo<int, User>(context);
                    int userId = Int32.Parse(Request.Cookies["user"]["id"]);
                    IQueryable<User> result = userRepository.FindBy(u => u.Id == userId);
                    submission.Authors = new List<User>();
                    submission.Authors.Add(result.First());
                    var submissionRepository = new AbstractCrudRepo<int, Submission>(context);
                    submissionRepository.Add(submission);
                    submissionRepository.Save();
                    
                }
                catch (Exception e)
                {
                    ViewBag.Message = "Something went wrong";
                    Console.WriteLine(e.Message);
                }
            }           
        }

        [HttpPost]
        public ActionResult Submit(Submission submission, HttpPostedFileBase proposal)
        {
            try
            {
                string folder = Server.MapPath("~/Submissions/");
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                int userId = Int32.Parse(Request.Cookies["user"]["id"]);
                string path = System.IO.Path.Combine(folder,
                    submission.Title + userId + System.IO.Path.GetExtension(proposal.FileName));
                proposal.SaveAs(path);
                ViewBag.Message = "File uploaded successfully";
                AddProposal(submission);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
            return Redirect("/");
        }

	}
}
using Conference_Management_System.Models;
using Conference_Management_System.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Conference_Management_System.Controllers
{
    public class AcceptRefuseProposalController : Controller
    {
        // GET: AcceptRefuseProposal
        public ActionResult Index()
        {
            return View();
        }
        private bool HasPermission()
        {
            return Helpers.DoesUserHaveRoles(Request, new Role[] { Role.SCM });
        }

        public void updatePapersStatus()
        {

            using (var context = new CMS())
            {
                var submissionRepo = new AbstractCrudRepo<int, Submission>(context);

                List<Submission> submissions = submissionRepo.FindAll().ToList();

                foreach (Submission submission in submissions)
                {
                    if (submission.Status == StatusValues.PENDING)
                    {
                        submission.Qualifiers = submission.Qualifiers.ToList();
                        List<Qualifier> myQualifiersA = submission.Qualifiers.ToList();
                        List<Qualifier> myQualifiersR = submission.Qualifiers.ToList();

                        int sizeA = myQualifiersA.Count;
                        int sizeR = myQualifiersR.Count;

                        myQualifiersA = myQualifiersA.Where(q => (q.Value == QualifierValues.ACCEPT) || (q.Value == QualifierValues.STRONG_ACCEPT) || (q.Value == QualifierValues.WEAK_ACCEPT)).ToList();
                        myQualifiersR = myQualifiersR.Where(q => (q.Value == QualifierValues.REJECT) || (q.Value == QualifierValues.STRONG_REJECT) || (q.Value == QualifierValues.WEAK_REJECT)).ToList();

                        if (sizeA == myQualifiersA.Count)
                        {
                            submission.Status = StatusValues.ACCEPT;
                        }
                        else
                        {
                            if (sizeR == myQualifiersR.Count)
                            {
                                submission.Status = StatusValues.REFUSE;
                            }
                        }

                        submissionRepo.Update(submission);
                        submissionRepo.Save();
                    }

                }
            }

        }


        [HttpGet]
        public ActionResult GetFinalPapers()
        {
            List<Submission> submissions = new List<Submission>();
            using (var context = new CMS())
            {
                var submissionRepo = new AbstractCrudRepo<int, Submission>(context);

                submissions = submissionRepo.FindAll().ToList();

                foreach (Submission submission in submissions)
                {
                    submission.Qualifiers = submission.Qualifiers;
                    foreach(Qualifier q in submission.Qualifiers)
                    {
                        q.Reviewer = q.Reviewer;
                    }
                }

            }
            return View(submissions);
        }




        [HttpGet]
        public ActionResult ChangeStatus(int id, StatusValues status)
        {
            using (var context = new CMS())
            {
               
                var submissionRepo = new AbstractCrudRepo<int, Submission>(context);

                List<Submission> submission = submissionRepo.FindBy(s => s.Id == id).ToList();
                Submission currentsubmission = submission.First();
                currentsubmission.Status = status;

                submissionRepo.Update(currentsubmission);
                submissionRepo.Save();

                Response.Redirect("/AcceptRefuseProposal/GetFinalPapers");

            }
            return GetFinalPapers();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Conference_Management_System.Repositories;
using Conference_Management_System.Models;

namespace Conference_Management_System.Controllers
{
    public class ProposalsController : Controller
    {
        //get images for the user that has id as ident.
        public ActionResult Bid()
        {
            using (var context = new CMS())
            {
                var submissionsRepo = new AbstractCrudRepo<int, Submission>(context);
                IQueryable<Submission> submisions = submissionsRepo.FindAll();
                
                return View();
            }

        }
    }
}

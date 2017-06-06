using Conference_Management_System.Models;
using Conference_Management_System.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Conference_Management_System.Controllers
{
    public class SignupForSectionController : Controller
    {
        public SignupForSectionController() { }

        [HttpGet]
        public ActionResult GetAllSections()
        {
            List<Section> sections;
            using (var context = new CMS())
            {
                var sectionRepo = new AbstractCrudRepo<int, Section>(context);

                // get all the sections
                sections = sectionRepo.FindAll().ToList();
                foreach(Section section in sections)
                {
                    section.Conference = section.Conference;
                }
            }

            return View(sections);
        }


        [HttpGet]
        public ActionResult Add(int sectionId)
        {
            List<Section> sections;
            using (var context = new CMS())
            {
                var sectionRepo = new AbstractCrudRepo<int, Section>(context);
                var userRepo = new AbstractCrudRepo<int, User>(context);
                User listener = null;
                //Get the user id from the session
                foreach (User user in userRepo.FindAll().ToList())
                {
                    if (user.Id == Int32.Parse(Request.Cookies["user"]["id"]))
                        listener = user;
                }

                // add the user to the section selected
                sections = sectionRepo.FindAll().ToList();
                foreach (Section sec in sections)
                {
                    if (sec.Id == sectionId)
                    { 
                        List<User> listeners;
                        if (sec.Listeners.Count == 0)
                        {
                            listeners = new List<User>();
                        }
                        else
                            listeners = sec.Listeners;

                        listeners.Add(listener);
                        sec.Listeners = listeners;
                        sectionRepo.Update(sec);
                        sectionRepo.Save();
                    }
                }
            }
          
            return RedirectToAction("GetAllSections");
        }
    }
}
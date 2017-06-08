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
            List<Section> allSections = new List<Section>();
            List<Section> sections;
            List<Section> userSections = new List<Section>();
            using (var context = new CMS())
            {
                var sectionRepo = new AbstractCrudRepo<int, Section>(context);

                int userId = Int32.Parse(Request.Cookies["user"]["id"]);
                // get all the sections
                sections = sectionRepo.FindAll().ToList();
                bool a = false;
                foreach(Section section in sections)
                {
                    a = false;
                    section.Conference = section.Conference;
                    section.Listeners = section.Listeners;
                    foreach (User user in section.Listeners)
                        if (user.Id == userId)
                        {
                            userSections.Add(section);
                            a = true;
                        }
                        
                    if(a==false)
                        allSections.Add(section);

                }
            }

            SectionsListeners sl = new SectionsListeners(allSections, userSections);
            return View(sl);
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

        [HttpGet]
        public ActionResult Delete(int sectionId)
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


                // delete the user to the section selected
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

                        listeners.Remove(listener);
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
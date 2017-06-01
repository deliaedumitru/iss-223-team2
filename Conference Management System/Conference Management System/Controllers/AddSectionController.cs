using Conference_Management_System.Models;
using Conference_Management_System.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Conference_Management_System.Controllers
{
    public class AddSectionController : Controller
    {
        public AddSectionController() { }

        [HttpGet]
        public ActionResult AddSection()
        {
            Section section = new Section();

            List<Conference> conferences;
            using (var context = new CMS())
            {
                var conferencesRepo = new AbstractCrudRepo<int, Conference>(context);
            
                //get conferences
                conferences = conferencesRepo.FindAll().ToList();
            }
            SectionConference sc = new SectionConference(section, conferences);

            return View(sc);
        }

        [HttpPost]
        public ActionResult AddSection(SectionConference sc)
        {
            using (var context = new CMS())
            {
                var conferenceRepo = new AbstractCrudRepo<int, Conference>(context);
                var sectionRepo = new AbstractCrudRepo<int, Section>(context);
                Conference conference=null;
                foreach (Conference conf in conferenceRepo.FindAll())
                {
                    if (conf.Id == sc.selectedId)
                        conference = conf;
                }

                sc.Section.Conference = conference;
                //add section and save the changes
                sectionRepo.Add(sc.Section);
                sectionRepo.Save();
            }

            return Redirect("/");
        }

    }
}
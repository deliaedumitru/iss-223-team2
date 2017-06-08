﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Conference_Management_System.Models;
using Conference_Management_System.Repositories;

namespace Conference_Management_System.Controllers
{
    public class ConferenceController : Controller
    {
        public ConferenceController()
        {

        }

        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            using (var context = new CMS())
            {
                var repo = new AbstractCrudRepo<int, Conference>(context);
                return View(repo.FindAll().ToList());
            }
        }



        [HttpGet]
        public ActionResult PostInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PostInfo(Conference conference)
        {
            using (var context = new CMS())
            {
                var repo = new AbstractCrudRepo<int, Conference>(context);
                repo.Add(conference);
                repo.Save();
            }

            return Redirect("/");
        }
    }
}
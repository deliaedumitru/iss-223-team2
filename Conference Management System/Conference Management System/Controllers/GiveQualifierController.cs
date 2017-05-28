using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Conference_Management_System.Repositories;
using Conference_Management_System.Models;

namespace Conference_Management_System.Controllers
{
    public class GiveQualifierController : Controller
    {
        ICrudRepository<Int32, Qualifier> _QualifierRepository;

        public GiveQualifierController(ICrudRepository<Int32, Qualifier> qualrep)
        {
            _QualifierRepository = qualrep;
        }

        public GiveQualifierController() { }

        // GET: GiveQualifier
        [HttpGet]
        public ActionResult GiveQualifier()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GiveQualifier(Qualifier qualifier)
        {
            _QualifierRepository.Add(qualifier);
            return View();
        }
    }
}
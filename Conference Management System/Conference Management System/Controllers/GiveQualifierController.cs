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
        ICrudRepository<Int32, Recommendation> _RecommendationRepository;

        public GiveQualifierController(ICrudRepository<Int32, Qualifier> qualrep, ICrudRepository<Int32, Recommendation> rec)
        {
            _QualifierRepository = qualrep;
            _RecommendationRepository = rec;
        }

        public GiveQualifierController() { }

        // GET: GiveQualifier
        [HttpGet]
        public ActionResult GiveQualifier()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddQualifier(Qualifier qualifier)
        {
            _QualifierRepository.Add(qualifier);
            _QualifierRepository.Save();
            return View();
        }

        [HttpPost]
        public ActionResult AddRecommendation(Recommendation recommendation)
        {
            _RecommendationRepository.Add(recommendation);
            _RecommendationRepository.Save();
            return View();
        }

        [HttpPost]
        public ActionResult Add(Qualifier qualifier, Recommendation recommendation)
        {
            this.AddQualifier(qualifier);
            this.AddRecommendation(recommendation);
            return View();
        }
    }
}

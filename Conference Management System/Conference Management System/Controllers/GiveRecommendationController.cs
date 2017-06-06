using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Conference_Management_System.Models;
using Conference_Management_System.Repositories;

namespace Conference_Management_System.Controllers
{
    public class GiveRecommendationController : Controller
    {
        ICrudRepository<Int32, Recommendation> _RecommendationRepository;

        public GiveRecommendationController(ICrudRepository<Int32, Recommendation> recommendationRepo)
        {
            _RecommendationRepository = recommendationRepo;
        }

        public GiveRecommendationController() { }

        // GET: GiveRecommendation
        public ActionResult Index()
        {
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
        public ActionResult Add(Recommendation recommendation)
        {
            this.AddRecommendation(recommendation);
            return View();
        }
    }
}
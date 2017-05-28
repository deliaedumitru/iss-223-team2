using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Conference_Management_System.Repositories;
using Conference_Management_System.Models;

namespace Conference_Management_System.Controllers
{
    public class ModifyQualifierController : Controller
    {
        ICrudRepository<Int32, Qualifier> _QualifierRepository;

        public ModifyQualifierController(ICrudRepository<Int32, Qualifier> qualrep)
        {
            _QualifierRepository = qualrep;
        }

        public ModifyQualifierController() { }

        // GET: ModifyQualifier
        [HttpGet]
        public ActionResult ModifyQualifier()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ModifyQualifier(Qualifier qualifier)
        {
            Func<Qualifier, bool> findOldQualifier = delegate (Qualifier s)
            { return s.Id.Equals(qualifier.Id); };

            if (_QualifierRepository.FindBy(x => findOldQualifier(x)).Count() != 0)
            {
                using (var db = new CMS())
                {
                    var query = from f in db.Qualifiers
                                where qualifier.Id == f.Id
                                select f;
                    Qualifier oldQualifier = query.First();
                    _QualifierRepository.Delete(oldQualifier.Id);
                    _QualifierRepository.Add(qualifier);
                }
            }
            return View();
        }
    }
}
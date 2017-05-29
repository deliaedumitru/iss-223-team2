using Conference_Management_System.Models;
using Conference_Management_System.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Conference_Management_System.Controllers
{
    public class LoginController:Controller
    {
        private ICrudRepository<Int32, User> _UserRepository;

        public LoginController(ICrudRepository<Int32, User> UserRepository)
        {
            _UserRepository = UserRepository;
        }

        public LoginController()
        {
           
        }


        [HttpGet]
        public ActionResult FindUserBy()
        {
            return View();
        }

        /*<summary>
      * Gets all the Users of the repository fulfilling a given username and password
      * </summary>
      * <returns> ActionResult,redirecting the user to its own page </returns> 
      */

        [HttpPost]
        public ActionResult FindUserBy(String username, String password)
        {
            using (var context = new CMS())
            {
                var userRepo = new AbstractCrudRepo<int, User>(context);

                Func<User, bool> findRole = delegate (User s)
                { return s.Username.Equals(username) & s.Password.Equals(password); };
                IQueryable<User> result = userRepo.FindBy(s => s.Username.Equals(username) && s.Password.Equals(password));
                if (result.Count() != 0)
                {
                    User user = result.First();
                    Response.Cookies["user"]["username"] = user.Username;
                    Response.Cookies["user"]["id"] = user.Id.ToString();
                    Response.Cookies["user"]["role"] = user.Role.ToString();
                    Response.Cookies["user"].Expires = DateTime.Now.AddDays(1);
                    switch (user.Role)
                    {
                        case Role.ADMIN:
                            return View("AdminView");
                        case Role.AUTHOR:
                            return View("AuthorView");
                        case Role.CHAIR:
                            return View("ChairView");
                        case Role.CO_CHAIR:
                            return View("CoChairView");
                        case Role.LISTENER:
                            return View("ListenerView");
                        case Role.PCM:
                            return View("PcmView");
                        case Role.SCM:
                            return View("ScmView");
                    }
                    return View();  //redirect to user page after login
                }
                return View(FindUserBy());
            }
        }

    }
}

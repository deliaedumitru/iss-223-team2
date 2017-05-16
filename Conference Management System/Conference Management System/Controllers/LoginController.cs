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
    public class LoginController
    {
        private ICrudRepository<String, User> _UserRepository;

        public LoginController(ICrudRepository<String, User> UserRepository)
        {
            _UserRepository = UserRepository;
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
            Func<User, bool> findRole = delegate (User s)
            { return s.Username.Equals(username) & s.Password.Equals(password); };

            if (_UserRepository.FindBy(Expression.Lambda<Func<User, bool>>(Expression.Call(findRole.Method))).Count()!=0)
                return Redirect('/');  //redirect to user page after login
                //return View();
            //return ErrorView();   //redirect to error page

        }

    }
}

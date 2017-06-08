using System;
using System.Linq;
using System.Web;
using Conference_Management_System.Models;

namespace Conference_Management_System.Controllers
{
    public class Helpers
    {
        public static int? GetUserId(HttpRequestBase request)
        {
            String id = null;
            if(request.Cookies["user"] != null)
                id = request.Cookies["user"]["id"]; // check if cookie is really set 
            if (id == null) return null;
            return Int32.Parse(id); // only if present, try to parse value
        }

        public static User GetUser(HttpRequestBase request)
        {
            var id = Helpers.GetUserId(request);
            if (id == null)
                return null; // no user to find
            using (var context = new CMS())
            {
                return context.Users.Find(id);
            }
        }

        public static bool DoesUserHaveRoles(HttpRequestBase request, Role[] roles)
        {
            var currentUser = Helpers.GetUser(request);
            if (currentUser == null)
                return false;
            // checks whether the current user has any of the specified roles
            return roles.Contains(currentUser.Role);
        }
    }
}
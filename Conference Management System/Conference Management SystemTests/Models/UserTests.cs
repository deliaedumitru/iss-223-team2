using Microsoft.VisualStudio.TestTools.UnitTesting;
using Conference_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conference_Management_System.Models.Tests
{
    [TestClass()]
    public class UserTests
    {
        [TestMethod()]
        public void UserTest()
        {
            using (var context = new CMS())
            {
                // Perform data access using the context 
                context.Users.Add(new User("mihai", "aaaa", Role.ADMIN, "mihai ion", "a@a.gmail.com", "comapnie"));
                context.SaveChanges();
            }
            using (var context = new CMS())
            {
                // Perform data access using the context 
                var x = from u in context.Users
                        where u.Username == "mihai"
                        select u;
                var email = x.First().Email;
                Assert.AreEqual(email, "a@a.gmail.com");
            }

        }
    }
}
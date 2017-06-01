using Microsoft.VisualStudio.TestTools.UnitTesting;
using Conference_Management_System.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conference_Management_System.Models;

namespace Conference_Management_System.Repositories.Tests
{ 
    [TestClass()]
    public class AbstractCrudRepoTests
    {
        [TestMethod()]
        public void AddTest()
        {
            using (var context = new CMS())
            {
                var userRepo = new AbstractCrudRepo<int, User>(context);
                // Perform data access using the context 
                userRepo.Add(new User("mihai", "aaaa", Role.ADMIN, "mihai ion", "a@a.gmail.com", "comapnie"));
                userRepo.Save();

                // check
                var user = userRepo.FindBy(x => x.Username == "mihai").First();
                Assert.AreEqual(user.Affiliation, "comapnie");
            }

        }

        [TestMethod()]
        public void DeleteTest()
        {
            using (var context = new CMS())
            {
                var userRepo = new AbstractCrudRepo<int, User>(context);
                // Perform addition
                var user = userRepo.Add(new User("radu", "gelu", Role.ADMIN, "gelu ion", "gelua@a.gmail.com", "compt"));
                userRepo.Save();
                Assert.AreEqual(user.Username, "radu");

                // get the id to delete
                var userId = userRepo.FindBy(x => x.Username == "radu").First().Id;
                userRepo.Delete(userId);
                userRepo.Save();
             
                Assert.IsTrue(!userRepo.FindBy(x => x.Username == "radu").Any());
            }
        }

     
        [TestMethod()]
        public void UpdateTest()
        {
            using (var context = new CMS())
            {
                var userRepo = new AbstractCrudRepo<int, User>(context);
                // Perform data access using the context 
                var user = userRepo.Add(new User("misu", "misu", Role.ADMIN, "gelu ion", "gelua@a.gmail.com", "compt"));
                userRepo.Save();

                user.Affiliation = "aaaa";
                var res = userRepo.Update(user);
                userRepo.Save();
                Assert.AreEqual(user.Username, "misu");

                var newUser = userRepo.FindBy(x => x.Username == "misu").First();
                Assert.AreEqual(newUser.Affiliation, "aaaa");
            }
        }

        [TestInitialize]
        public void SetupTest()
        {
            var _db = new CMS();
            _db.Database.Initialize(force: true);
            var _dbResults = new CMS();

            // This forces the database to initialise at this point with the initialization data / Empty DB
            var count = _db.Users.Count();
            var resultCount = _dbResults.Users.Count();
            if (count != resultCount) throw new InvalidOperationException("We do not have a consistant DB experiance.");
        }
    }
}
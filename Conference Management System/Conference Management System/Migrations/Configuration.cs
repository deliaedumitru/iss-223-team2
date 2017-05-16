using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using Conference_Management_System.Models;

namespace Conference_Management_System.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DatabaseContext context)
        {
            var users = new User[]
            {
                new User
                {
                    Id = 1,
                    Username = "test",
                    Name = "Name Test",
                    Affiliation = "pqr",
                    Password = "test",
                    Role = Role.AUTHOR,
                    Email = "test@test.com"
                },
                new User
                {
                    Id = 2,
                    Username = "admin",
                    Name = "Joe Lawrie",
                    Affiliation = "mno",
                    Password = "admin",
                    Role = Role.ADMIN,
                    Email = "joe@cms.com"
                },
                new User
                {
                    Id = 3,
                    Username = "wiley_k",
                    Name = "Wiley Kurtis",
                    Affiliation = "jkl",
                    Password = "pass",
                    Role = Role.AUTHOR,
                    Email = "wiley@gmail.com"
                },
                new User
                {
                    Id = 4,
                    Username = "jermaine_w",
                    Name = "Jermaine Wilt",
                    Affiliation = "ghi",
                    Password = "pass",
                    Role = Role.CHAIR,
                    Email = "wilt@google.com"
                },
                new User
                {
                    Id = 5,
                    Username = "warner_j",
                    Name = "Warner Jameson",
                    Affiliation = "def",
                    Password = "pass",
                    Role = Role.CO_CHAIR,
                    Email = "wilt@google.com"
                },
                new User
                {
                    Id = 6,
                    Username = "issy_g",
                    Name = "Issy Gil",
                    Affiliation = "abc",
                    Password = "pass",
                    Role = Role.LISTENER,
                    Email = "gil_issy@google.com"
                }
            };

            context.Users.AddOrUpdate(users);
        }
    }
}
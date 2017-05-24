using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Conference_Management_System.Models
{
    public class User : Entity<int>
    {
        public User()
        {
        }

        public User(String username, String password, Role role, String name, String email, String affiliation)
        {
            this.Username = username;
            this.Password = password;
            this.Role = role;
            this.Name = name;
            this.Email = email;
            this.Affiliation = affiliation;
        }

        public String Username { get; set; }
        public String Password { get; set; }
        public Role Role { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String Affiliation { get; set; }
        public String ToString() { return Username + " " + Password + " " + Role + " " + Name + " " + Email + " " + Affiliation; }
    }
}
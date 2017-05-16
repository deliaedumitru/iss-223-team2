using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Conference_Management_System.Models
{
    public class User : Entity<String>
    {
        private String username;
        private String password;
        private Role role;
        private String name;
        private String email;
        private String affiliation;

        public User()
        {
            username = "";
            password = "";
            role = Role;
            name = "";
            email = "";
            affiliation = "";
        }

        public User(String username, String password, Role role, String name, String email, String affiliation)
        {
            this.username = username;
            this.password = password;
            this.role = role;
            this.name = name;
            this.email = email;
            this.affiliation = affiliation;
        }

        public String Username { get { return username; } set { username = value; } }
        public String Password { get { return password; } set { password = value; } }
        public Role Role { get { return role; } set { role = value; } }
        public String Name { get { return name; } set { name = value; } }
        public String Email { get { return email; } set { email = value; } }
        public String Affiliation { get { return affiliation; } set { affiliation = value; } }
        public String ToString() { return username + " " + password + " " + role + " " + name + " " + email + " " + affiliation; }
    }
}
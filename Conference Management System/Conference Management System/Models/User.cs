using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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


        [InverseProperty("Reviewers")] // required when more than one many-to-many relationships are present
        public virtual List<Submission> ReviewedSubmissions { get; set; }
        [InverseProperty("Authors")]
        public virtual ICollection<Submission> Submissions { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Bid> Bids { get; set; }
        public String ToString() { return Username + " " + Password + " " + Role + " " + Name + " " + Email + " " + Affiliation; }

    }
}
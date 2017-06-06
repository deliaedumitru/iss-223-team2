using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Conference_Management_System.Models
{
    public class Fee : Entity<int>
    {
        public Fee() { }

        public Fee(FeeType type, User user, Conference conference)
        {
            this.Type = type;
            this.User = user;
            this.Conference = conference;
        }

        public FeeType Type { get; set; }
        public virtual User User { get; set; }
        public virtual Conference Conference { get; set; }
    }
}
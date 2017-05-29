using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Conference_Management_System.Models
{
    public class Bid : Entity<int>
    {
        int id;
        BidValues value;

        public Bid()
        {
        }

        public Bid(int id, BidValues value)
        {
            base.Id = id;
            this.value = value;
        }
        public BidValues Value { get; set; }

        public virtual User Reviewer { get; set; }
        public virtual Submission Submission { get; set; }
    }
}

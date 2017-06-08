using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Conference_Management_System.Models
{
    public class Qualifier : Entity<int>
    {

 
        public Qualifier()
        {
   
        }

        public Qualifier(int id, User reviewer, Submission paper, QualifierValues value)
        {
            this.Id = id;
            this.Reviewer = reviewer;
            this.Paper = paper;
            this.Value = value;
        }

        public virtual User Reviewer { get; set; }
        public virtual Submission Paper { get; set; }
        public QualifierValues Value { get; set; }

    }
}
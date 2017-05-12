using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Conference_Management_System.Models
{
    public class Qualifier : Entity<int>
    {

        int id;
        Entity<int> reviewer;
        Entity<int> paper;
        QualifierValues value;

        public Qualifier()
        {
            id = 0;
            //reviewer = new Reviewer();
            paper = new Submission();
            value = QualifierValues.REJECT;
        }

        public Qualifier(int id, Entity<int> reviewer, Submission paper, QualifierValues value)
        {
            this.id = id;
            this.reviewer = reviewer;
            this.paper = paper;
            this.value = value;
        }

        public Entity<int> Reviewer { get { return reviewer; } set { reviewer = value; } }
        public Entity<int> Paper { get { return paper; } set { paper = value; } }
        public QualifierValues Value { get { return value; } set { this.value = value; } }

    }
}
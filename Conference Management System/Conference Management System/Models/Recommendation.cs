using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Conference_Management_System.Models
{
    public class Recommendation:Entity<int>
    {
        private int id;
        private String text;
        private int reviewerId;
        private int submissionId;

        public Recommendation() { }

        public Recommendation(int id,String text, int reviewerId, int submissionId) {
            this.id = id;
            this.text = text;
            this.reviewerId = reviewerId;
            this.submissionId = submissionId;
        }

        public String  Text
        {
            get { return text; }
            set { text = value; }
        }

        public int ReviewerId
        {
            get { return reviewerId; }
            set { reviewerId = value; }
        }

        public int SubmissionId
        {
            get { return submissionId; }
            set { submissionId = value; }
        }


    }
}


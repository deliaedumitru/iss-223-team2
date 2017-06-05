using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Conference_Management_System.Models
{
    public class Recommendation:Entity<int>
    {
        public Recommendation()
        {
        }

        public Recommendation(int id,String text, int reviewerId, int submissionId) {
            this.Id = id;
            this.Text = text;
            this.ReviewerId = reviewerId;
            this.SubmissionId = submissionId;
        }

        public Recommendation(int id, String text, User reviewer, Submission submission)
        {
            this.Id = id;
            this.Text = text;
            this.Rewiever = reviewer;
            this.Submission = submission;
        }

        public String  Text
        { get; set; }

        public int ReviewerId
        { get; set; }

        public int SubmissionId
        { get; set; }

        public virtual Submission Submission { get; set; }

        public virtual User Rewiever { get; set; }


    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Conference_Management_System.Models
{
    public class Comment: Entity<int>
    {
        public Comment()
        {
        }

        public Comment(int id, String text, DateTime date, User reviewer, Submission submission)
        {
            Id = id;
            Text = text;
            Date = date;
            Reviewer = reviewer;
            Submission = submission;
        }

        public String Text { get; set; }
        public DateTime Date { get; set; }
        public virtual User Reviewer { get; set; }
        public virtual Submission Submission { get; set; }

        public override string ToString()
        {
            return string.Format("Text: {0}, Date: {1}, Reviewer: {2}, Submission: {3}", Text, Date, Reviewer.Name, Submission.Id);
        }
    }
}
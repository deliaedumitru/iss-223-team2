using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Conference_Management_System.Models
{
    public class Comment: Entity<int>
    {
        private String _text;
        private DateTime _date;
        private Entity<int> _reviewer;
        private Entity<int> _submission;

        public Comment(int id, String text, DateTime date, Entity<int> reviewer, Entity<int> submission)
        {
            Id = id;
            _text = text;
            _date = date;
            _reviewer = reviewer;
            _submission = submission;
        }

        public String Text { get { return _text; } set { _text = value; } }
        public DateTime Date { get { return _date; } set { _date = value; } }
        public virtual User Reviewer { get; set; }
        public virtual Submission Submission { get; set; }

        public override string ToString()
        {
            return string.Format("Text: {0}, Date: {1}, Reviewer: {2}, Submission: {3}", _text, _date, _reviewer, _submission);
        }
    }
}
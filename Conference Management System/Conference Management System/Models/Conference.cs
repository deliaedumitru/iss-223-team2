using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Conference_Management_System.Models
{
    public class Conference : Entity<int>
    {
        public Conference()
        {
        }

        public Conference(int id, string name, DateTime date, DateTime startTime, DateTime endTime, DateTime submissionDeadline, string location)
        {
            Id = id;
            Name = name;
            Date = date;
            StartTime = startTime;
            EndTime = endTime;
            SubmissionDeadline = submissionDeadline;
            Location = location;
        }

        public Conference(int id, string name, DateTime date, DateTime startTime, DateTime endTime, 
            DateTime submissionDeadline, string location, Decimal authorFee, Decimal listenerFee)
        {
            Id = id;
            Name = name;
            Date = date;
            StartTime = startTime;
            EndTime = endTime;
            SubmissionDeadline = submissionDeadline;
            Location = location;
            AuthorFee = authorFee;
            ListenerFee = listenerFee;
        }

        public string Name
        { get; set; }

        public DateTime Date
        { get; set; }

        public DateTime StartTime
        { get; set; }

        public DateTime EndTime
        { get; set; }

        public DateTime SubmissionDeadline
        { get; set; }

        public string Location
        { get; set; }

        public Decimal AuthorFee { get; set; }

        public Decimal ListenerFee { get; set; }

        public virtual ICollection<Submission> Submissions { get; set; }
    }
}
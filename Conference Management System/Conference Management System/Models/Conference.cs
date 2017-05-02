using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Conference_Management_System.Models
{
    public class Conference : Entity<int>
    {

        private String _name;
        private DateTime _date;
        private DateTime _startTime;
        private DateTime _endTime;
        private DateTime _submissionDeadline;
        private String _location;

        public Conference(int id, string name, DateTime date, DateTime startTime, DateTime endTime, DateTime submissionDeadline, string location)
        {
            _id = id;
            _name = name;
            _date = date;
            _startTime = startTime;
            _endTime = endTime;
            _submissionDeadline = submissionDeadline;
            _location = location;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public DateTime StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        public DateTime EndTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }

        public DateTime SubmissionDeadline
        {
            get { return _submissionDeadline; }
            set { _submissionDeadline = value; }
        }

        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Conference_Management_System.Models.DTO
{
    public class ConferenceDTO
    {
        public int Id { get; set; }
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

    }
}
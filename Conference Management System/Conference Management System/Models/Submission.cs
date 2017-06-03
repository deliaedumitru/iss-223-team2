
﻿using System;
using System.Collections.Generic;
 using System.ComponentModel.DataAnnotations.Schema;
 using System.Linq;
using System.Web;

namespace Conference_Management_System.Models
{
    public class Submission : Entity<int>
    {
        public Submission()
        {
        }

        public Submission(int id, string title, string meta, string type)
        {
            base.Id = id;
            this.Title = title;
            this.Meta = meta;
            this.Type = type;
            this.Status = StatusValues.PENDING;
        }
        public string Title
        { get; set; }

        public string Meta
        { get; set; }

        public string Type { get; set; }
        
        public StatusValues Status { get; set; }


        [InverseProperty("Submissions")] // required when more than one many-to-many relationships are present
        public virtual List<User> Authors { get; set; }

        [InverseProperty("ReviewedSubmissions")]
        public virtual ICollection<User> Reviewers { get; set; }

        public virtual ICollection<Bid> Bids
        { get; set; }

        public virtual ICollection<Qualifier> Qualifiers
        { get; set; }

        public virtual ICollection<Recommendation> Recommendations
        { get; set; }

        public virtual ICollection<Comment> Comments
        { get; set; }

        public virtual Conference Conference { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, Title: {1}, Meta: {2}, Type: {3}", this.Id, this.Title, this.Meta, this.Type);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Conference_Management_System.Models
{
    public class Submission : Entity<int>
    {
        private string _meta;
        private string _type;
        private List<Entity<int>> _authors;
        private List<Entity<int>> _bids;
        private List<Entity<int>> _qualifiers;
        private List<Entity<int>> _recommendations;
        private List<Entity<int>> _comments;

        public Submission()
        {
            this.Authors = new List<Entity<int>>();
            this.Bids = new List<Entity<int>>();
            this.Qualifiers = new List<Entity<int>>();
            this.Recommendations = new List<Entity<int>>();
            this.Comments = new List<Entity<int>>();
        }
        public Submission(int id, string meta, string type)
        {
            base.Id = id;
            this.Meta = meta;
            this.Type = type;
        }

        public string Meta
        {
            get { return _meta; }
            set { _meta = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public List<Entity<int>> Authors
        {
            get { return _authors; }
            set { _authors = value; }
        }

        public List<Entity<int>> Bids
        {
            get { return _bids; }
            set { _bids = value; }
        }

        public List<Entity<int>> Qualifiers
        {
            get { return _qualifiers; }
            set { _qualifiers = value; }
        }

        public List<Entity<int>> Recommendations
        {
            get { return _recommendations; }
            set { _recommendations = value; }
        }

        public List<Entity<int>> Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }

        public override string ToString()
        {
            return string.Format("Id: {0}, Meta: {1}, Type: {2}", this.Id, this.Meta, this.Type);
        }
    }
}

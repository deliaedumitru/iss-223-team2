using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Conference_Management_System.Models
{
    public class SectionConference
    {
        Section section;
        IEnumerable<SelectListItem> conferences;

        public SectionConference() { }

        public SectionConference(Section section,IEnumerable<Conference> conferences)
        {
            this.section = section;
            this.conferences = new SelectList(conferences, "Id", "Name");
        }

        public int selectedId { get; set; }

        public Section Section { get { return section; } set { section = value; } }
        public IEnumerable<SelectListItem> Conferences { get { return conferences; } set { conferences = value; } }
    }
}
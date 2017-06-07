using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Conference_Management_System.Models
{
    public class SectionsListeners
    {
        List<Section> allSections;
        List<Section> userSections;
       
        public SectionsListeners(List<Section> allSections,List<Section> userSections)
        {
            this.allSections = allSections;
            this.userSections = userSections;
        }

        public List<Section> AllSections { get{ return allSections; } set{ allSections = value; } }
        public List<Section> UserSections { get { return userSections; } set { userSections = value; } }
                
    }
}
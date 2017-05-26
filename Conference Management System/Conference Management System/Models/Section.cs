using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Conference_Management_System.Models
{
    public class Section : Entity<int>
    {
        public Section()
        {

        }

        public Section(int id, String name, String room, int seatNumber, Conference conference)
        {
            Id = id;
            Name = name;
            Room = room;
            SeatNumber = seatNumber;
            Conference = conference;
        }

        public String Name { get; set; }
        public String Room { get; set; }
        public int SeatNumber { get; set; }

        public virtual Conference Conference;
        
        public virtual List<User> Listeners
        { get; set; }

        public virtual List<User> Speakers
        { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {0}, Room: {1}, SeatNumber: {2}, Conference: {3}", Name, Room, SeatNumber, Conference.Name);
        }

    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Conference_Management_System.Models
{
    public class Bid : Entity<int>
    {
        public Bid(int id)
        {
            base.Id = id;
        }
    }
}
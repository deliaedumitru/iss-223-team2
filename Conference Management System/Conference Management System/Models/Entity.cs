using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Conference_Management_System.Models
{
    public abstract class Entity<T> : IHasId<T>
    {

        private T id;

        public T Id { get => id; set => id = value; }

    }
}
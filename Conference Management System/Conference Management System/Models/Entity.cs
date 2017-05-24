using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Conference_Management_System.Models
{
    public interface IHasID<T>
    {
        T Id { get; set; }
    }

    public abstract class Entity<T> : IHasID<T>
    {
        public T Id
        { get; set; }

    }

   
}
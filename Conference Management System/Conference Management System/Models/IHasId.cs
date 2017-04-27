using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conference_Management_System.Models
{
    interface IHasId<T>
    {

        T Id { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conference_Management_System.Validators
{
    class ValidatorException : SystemException
    {
        public ValidatorException(string message) : base(message) { }
    }
}

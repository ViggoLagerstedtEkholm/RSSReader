using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Exceptions
{
    public class InvalidStringException : CustomException
    {
        public InvalidStringException() { }

        public override string ErrorMessage()
        {
            var error = "String is empty!";
            return error;
        }
    }
}

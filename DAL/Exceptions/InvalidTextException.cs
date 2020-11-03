using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Exceptions
{
    public class InvalidTextException : CustomException
    {
        public InvalidTextException() { }

        public override string ErrorMessage()
        {
            var error = "Make sure to have all the text fields filled with information!";
            return error;
        }
    }
}

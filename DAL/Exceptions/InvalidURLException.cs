using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Exceptions
{
    public class InvalidURLException : CustomException
    {
        public InvalidURLException() { }

        public override string ErrorMessage()
        {
            var error = "Make sure you have the right URL!";
            return error;
        }
    }
}

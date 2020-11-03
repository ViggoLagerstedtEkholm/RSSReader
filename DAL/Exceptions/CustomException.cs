using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException() : base("An error has occured") { }

        public virtual string ErrorMessage()
        {
            var error = "An error has been caught.";
            return error;
        }
    }
}

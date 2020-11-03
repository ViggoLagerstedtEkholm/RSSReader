using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Exceptions
{
    public class InvalidComboBoxException : CustomException
    {
        public InvalidComboBoxException() { }

        public override string ErrorMessage()
        {
            var error = "Make sure to select a category and interval!";
            return error;
        }
    }
}

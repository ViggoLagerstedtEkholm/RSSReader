using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Exceptions
{
    public class InvalidListBoxException : CustomException
    {
        public InvalidListBoxException() { }

        public override string ErrorMessage()
        {
            var error = "Make sure to select a category from the category list!";
            return error;
        }
    }
}

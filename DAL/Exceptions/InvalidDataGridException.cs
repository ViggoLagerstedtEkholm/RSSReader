using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Exceptions
{
    public class InvalidDataGridException : CustomException
    {
        public InvalidDataGridException() { }

        public override string ErrorMessage()
        {
            var error = "Make sure to select a podcast from the table!";
            return error;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public sealed class Constants
    {

        public static readonly Constants category = new Constants("Category");
        public static readonly Constants podcast = new Constants("Podcast");

        private Constants(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }
        
    }
}

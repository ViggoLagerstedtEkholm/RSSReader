using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Category
    {
        //public int id { get; set; }
        public string namn { get; set; }

        public Category(string namn)
        {
            this.namn = namn;
        }
    }
}

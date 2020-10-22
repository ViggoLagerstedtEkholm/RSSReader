using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Category
    {
        public string namn { get; set; }
        public Category(string name)
        {
            this.namn = name;
        }

        public Category()
        {

        }
    }
}

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
        public string Namn { get; set; }
        public override string ToString()
        {
            return Namn;
        }
        public Category(string name)
        {
            this.Namn = name;
        }

        public Category()
        {

        }
    }
}

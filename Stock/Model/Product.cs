using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Model
{
    public class Product
    {
        public int ID { get; set; }

        public int CategoryID { get; set; }

        public string Code { get; set; }

        public string CategoryName{ get; set; }

        public string Name { get; set; }

        public int ReOrderLevel { get; set; }

        public string Description { get; set; }
    }
}

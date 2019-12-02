using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Model
{
    class SalesProduct
    {
        public int ID { get; set; }

        public string SalesCode { get; set; }

        public string ProductName{ get; set; }

        public string ProductCode { get; set; }

        public string CustomerName { get; set; }

        public DateTime SalesDate { get; set; }

        public int Quantity { get; set; }

        public double TotalMRP { get; set; }

        public double MRP { get; set; }

        
    }
}

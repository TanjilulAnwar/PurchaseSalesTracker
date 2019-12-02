using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Model
{
    class PurchasedProduct
    {
        public int ID { get; set; }

        public string PurchaseCode { get; set; }

        public string ProductCode { get; set; }

        public DateTime MfgDate { get; set; }

        public DateTime ExpDate { get; set; }

        public int Quantity { get; set; }

        public double UnitPrice { get; set; }

        public double TotalPrice { get; set; }

        public double MRP{ get; set; }

        public string Remarks { get; set; }
       


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Model
{
    class Purchase
    {
        public int ID { get; set; }

        public DateTime Date { get; set; }

        public string InvoiceNo { get; set; }

        public string Code { get; set; }

        public int SupplierID { get; set; }

        public List<PurchasedProduct> purchasedProducts = new List<PurchasedProduct>();

        //public Purchase()
        //{
        //    purchasedProducts = new List<PurchasedProduct>();
        //}


    }
}

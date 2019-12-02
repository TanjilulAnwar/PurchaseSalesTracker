using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Model
{
    class Sales
    {

        public int ID { get; set; }
        public string CustomerCode {get; set;}
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public List<SalesProduct> salesProducts ;

    }
}

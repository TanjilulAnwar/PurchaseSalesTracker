using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stock.Repository;
using Stock.BLL;
using Stock.Model;

namespace Stock.BLL
{
    class SalesManager
    {
        SalesRepository _salesRepository = new SalesRepository();

        public List<Customer> CustomerComboDisplay()
        {
            return _salesRepository.CustomerComboDisplay();
        }

        public int FetchLoyaltyPoint(Customer customer)
        {
            return _salesRepository.FetchLoyaltyPoint(customer);
        }

        public bool SalesAdd(Sales sales)
        {
            return _salesRepository.SalesAdd(sales);
        }

        public string fetchCustomerCode(Customer customer)
        {
            return _salesRepository.fetchCustomerCode(customer);
        }
        public string fetchPreviousCode()
        {
            return _salesRepository.fetchPreviousCode();
        }


        public List<Category> CategoryComboDisplay()
        {
            return _salesRepository.CategoryComboDisplay();
        }

        public List<Product> ProductComboDisplay(Product product)
        {

            return _salesRepository.ProductComboDisplay(product);
        }

        public string fetchProductCode(Product product)
        {
            return _salesRepository.fetchProductCode(product);
        }

        public bool ProductAdd(SalesProduct salesProduct)
        {
            return _salesRepository.ProductAdd(salesProduct);
        }



    }
}

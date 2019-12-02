using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stock.Model;
using Stock.Repository;

namespace Stock.BLL
{
    class PurchaseManager
    {
        PurchaseRepository _purchaseRepository = new PurchaseRepository();

        public bool PurchaseAdd(Purchase purchase)
        {
            return _purchaseRepository.PurchaseAdd(purchase);
        }

        public string fetchPreviousCode()
        {
            return _purchaseRepository.fetchPreviousCode();
        }

        public List<Supplier> SupplierComboDisplay()
        {
            return _purchaseRepository.SupplierComboDisplay();
        }

        public List<Category> CategoryComboDisplay()
        {
            return _purchaseRepository.CategoryComboDisplay();
        }

        public List<Product> ProductComboDisplay(Product product)
        {
            return _purchaseRepository.ProductComboDisplay(product);
        }


        public string fetchProductCode(Product product)
        {
            return _purchaseRepository.fetchProductCode(product);
        }

        public bool ProductAdd(PurchasedProduct purchasedProduct)
        {
            return _purchaseRepository.ProductAdd(purchasedProduct);
        }
        public List<PurchasedProduct> SearchPurchasedProducts(string item)
        {
            return _purchaseRepository.SearchPurchasedProducts(item);
        }
    }
}

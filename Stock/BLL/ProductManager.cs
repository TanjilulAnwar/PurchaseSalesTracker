using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stock.Model;
using Stock.Repository;

namespace Stock.BLL
{
    class ProductManager
    {
        ProductRepository _productRepository = new ProductRepository();

        public bool Add(Product product)
        {
            return _productRepository.Add(product);
        }
        public List<Category> ComboDisplay()
        {
            return _productRepository.CategoryComboDisplay();
        }
        public bool CheckName(Product product)
        {
            return _productRepository.CheckName(product);
        }

        public bool CheckCode(Product product)
        {
            return _productRepository.CheckCode(product);
        }
        public List<Product> Display()
        {
            return _productRepository.Display();

        }
        public bool Update(Product product)
        {
            return _productRepository.Update(product);
        }
        public List<Product> Search(string item)
        {
            return _productRepository.Search(item);
        }
    }
}

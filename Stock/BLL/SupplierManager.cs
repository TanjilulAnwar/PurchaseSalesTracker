using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stock.Model;
using Stock.Repository;


namespace Stock.BLL
{
    class SupplierManager
    {
        SupplierRepository _supplierRepository = new SupplierRepository();

        public bool Add(Supplier supplier)
        {
            return _supplierRepository.Add(supplier);
        }

        public bool CheckCode(Supplier supplier)
        {
            return _supplierRepository.CheckCode(supplier);
        }


        public bool CheckEmail(Supplier supplier)
        {
            return _supplierRepository.CheckEmail(supplier);
        }


            public bool CheckContact(Supplier supplier)
        {
            return _supplierRepository.CheckContact(supplier);
        }

        public List<Supplier> Search(string item)
        {
            return _supplierRepository.Search(item);

        }

        public List<Supplier> Display()
        {
            return _supplierRepository.Display();
        }
        public bool Update(Supplier supplier)
        {
            return _supplierRepository.Update(supplier);
        }


    }
}

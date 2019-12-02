using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stock.Model;
using Stock.Repository;

namespace Stock.BLL
{
    class CustomerManager
    {
        CustomerRepository _customerRepository = new CustomerRepository();

        public bool Add(Customer customer)
        {
            return _customerRepository.Add(customer);
        }

        public bool CheckCode(Customer customer)
        {
            return _customerRepository.CheckCode(customer);
        }
            public bool CheckEmail(Customer customer)
        {
            return _customerRepository.CheckEmail(customer);
        }
        public bool CheckContact(Customer customer)
        {
            return _customerRepository.CheckContact(customer);
        }


        public List<Customer> Display()
        {
            return _customerRepository.Display();
        }

        public bool Update(Customer customer)
        {
            return _customerRepository.Update(customer);
        }

        public List<Customer> Search(string item)
        {
            return _customerRepository.Search(item);
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using CustomerApp.Core.ApplicationService;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;

namespace CustomerApp.Infrastructure.Static.Data.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {

        static int id = 1;
        private List<Customer> _customers = new List<Customer>();

        public CustomerRepository()
        {
            if (FakeDb.Customers.Count >= 1) return;
            var cust1 = new Customer()
            {
                FirstName = "Jane",
                LastName = "Doe",
                Address = "503 SE 34th Terr"
            };

            FakeDb.Customers.Add(cust1);

            var cust2 = new Customer()
            {
                FirstName = "Jim",
                LastName = "Doe",
                Address = "418 Green St"
            };

            FakeDb.Customers.Add(cust2);


        }
        
        public Customer Create(Customer customer)
        {
            customer.Id = FakeDb.id++;
            FakeDb.Customers.Add(customer);
            return customer;
        }

        public IEnumerable<Customer> ReadAll()
        {
            return FakeDb.Customers.ToList();
        }

        public Customer ReadyById(int id)
        {
            foreach (var customer in _customers)
            {
                if (customer.Id == id)
                {
                    return customer;
                }
            }
            return null;
        }

        //Remove later when we use UOW
        public Customer Update(Customer customerUpdate)
        {
            var customerFromDB = this.ReadyById(customerUpdate.Id);
            if(customerFromDB != null) {
                customerFromDB.FirstName = customerUpdate.FirstName;
                customerFromDB.LastName = customerUpdate.LastName;
                customerFromDB.Address = customerUpdate.Address;
                return customerFromDB;
            }
            return null;
        }

        public Customer Delete(int id)
        {
            var customerFound = this.ReadyById(id);
            if (customerFound != null)
            {
                _customers.Remove(customerFound);
                return customerFound;
            }
            return null;
        }

    }
}

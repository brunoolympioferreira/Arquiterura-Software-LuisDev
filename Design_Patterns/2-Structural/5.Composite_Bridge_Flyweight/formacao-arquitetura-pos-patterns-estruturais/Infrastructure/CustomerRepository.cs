using AwesomeShopPatterns.API.Core.Entities;

namespace AwesomeShopPatterns.API.Infrastructure
{
    public class CustomerRepository : ICustomerRepository
    {
        public List<Customer> GetBlockedCustomers()
        {
            return new List<Customer>
            {
                new Customer("Fulano", DateTime.Now.AddYears(-20)),
                new Customer("Fulano", DateTime.Now.AddYears(-30)),
                new Customer("Fulano", DateTime.Now.AddYears(-40))
            };
        }
    }
}

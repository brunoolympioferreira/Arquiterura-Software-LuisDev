using AwesomeShopPatterns.API.Core.Entities;

namespace AwesomeShopPatterns.API.Infrastructure
{
    public interface ICustomerRepository
    {
        List<Customer> GetBlockedCustomers();
        Customer GetCustomerById(Guid id);
    }
}

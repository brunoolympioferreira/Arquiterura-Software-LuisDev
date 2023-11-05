using AwesomeShopPatterns.API.Core.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace AwesomeShopPatterns.API.Infrastructure.Proxies
{
    public class CustomerRepositoryProxy : ICustomerRepository
    {
        private readonly ICustomerRepository _repository;
        private readonly IMemoryCache _cache;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CustomerRepositoryProxy(ICustomerRepository repository, IMemoryCache cache, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _cache = cache;
            _httpContextAccessor = httpContextAccessor;
        }

        public List<Customer> GetBlockedCustomers()
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext == null)
                return null;

            if (httpContext.Request.Headers["x-role"] != "admin")
                return null;

            List<Customer> blockedCustomers = _cache.GetOrCreate("blocked-customers", c =>
            {
                return _repository.GetBlockedCustomers();
            });

            return blockedCustomers;
        }
    }
}

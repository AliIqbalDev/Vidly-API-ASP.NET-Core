using System.Collections.Generic;
using System.Threading.Tasks;
using Vidly_RESTful_API.Models;

namespace Vidly_RESTful_API.Services
{
    public interface IVidlyRepository
    {
        void AddCustomer(Customer customer);

        Task<IEnumerable<Customer>> GetCustomersAsync();

        Task<Customer> GetCustomerAsync(int customerId);

        void DeleteCustomer(Customer customer);
    }
}
using _01___Inicial.Models;

namespace _02___Resolvendo.Repository.Contracts
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetByIdAsync(string customerId);
    }
}

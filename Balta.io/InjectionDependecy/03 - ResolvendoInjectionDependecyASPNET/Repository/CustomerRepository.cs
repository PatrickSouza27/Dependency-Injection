using _01___Inicial.Models;
using _02___Resolvendo.Repository.Contracts;
using Dapper;
using System.Data.SqlClient;

namespace _02___Resolvendo.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SqlConnection _sqlConnection; 
        // readonly só é atribuido vindo do construtor
        //const é somente no momento da declaração a atribuição
        public CustomerRepository(SqlConnection sqlConnection)=> _sqlConnection = sqlConnection;
        public async Task<Customer?> GetByIdAsync(string customerId)
        {
            // #1 - Recupera o cliente
            const string query = "SELECT [Id], [Name], [Email] FROM CUSTOMER WHERE ID=@id";
            return await _sqlConnection.QueryFirstOrDefaultAsync<Customer>(query, new { id = customerId });
            
        }
    }
}

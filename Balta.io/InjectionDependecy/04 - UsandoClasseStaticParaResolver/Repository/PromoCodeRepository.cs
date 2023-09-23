using _01___Inicial.Models;
using _02___Resolvendo.Repository.Contracts;
using Dapper;
using System.Data.SqlClient;

namespace _02___Resolvendo.Repository
{
    public class PromoCodeRepository : IPromoCodeRepository
    {
        private readonly SqlConnection _sqlConnection;
        // readonly só é atribuido vindo do construtor
        //const é somente no momento da declaração a atribuição
        public PromoCodeRepository(SqlConnection sqlConnection) => _sqlConnection = sqlConnection;
        public async Task<PromoCode?> GetPromoCodeAsync(string promoCode)
        {
             const string query = "SELECT * FROM PROMO_CODES WHERE CODE=@code";
             return await _sqlConnection.QueryFirstAsync<PromoCode>(query, new { code = promoCode });
        }
    }
}

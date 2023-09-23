using _02___Resolvendo.Services.Contracts;
using RestSharp;

namespace _02___Resolvendo.Services
{
    public class DeliveryFeeService : IDeliveryFeeService
    {
        public async Task<decimal> GetDeliveryFeeAsync(string zipCode)
        {
            // #2 - Calcula o frete
            var client = new RestClient("https://consultafrete.io/cep/");
            var request = new RestRequest()
                .AddJsonBody(new
                {
                    zipCode
                });
            var response = await client.PostAsync<decimal>(request, new CancellationToken());

            // Nunca é menos que R$ 5,00
            return response < 5 ? 5 : response;
        }
    }
}

using _01___Inicial.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Data.SqlClient;
using Dapper;
using _02___Resolvendo.Repository.Contracts;
using _02___Resolvendo.Services.Contracts;

namespace Inicial.Controller
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IDeliveryFeeService _deliveryFeeService;
        private readonly IPromoCodeRepository _promoCodeRepository;
        public OrderController(ICustomerRepository customerRepository, IDeliveryFeeService deliveryService, IPromoCodeRepository promoCodeRepository)
        {
            _customerRepository = customerRepository;
            _deliveryFeeService = deliveryService;
            _promoCodeRepository = promoCodeRepository;
        }
        [Route("v1/orders")]
        [HttpPost]
        public async Task<IActionResult> Place(string customerId, string zipCode, string promoCode, int[] products)
        {
            // #1 - Recupera o cliente
            var customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer is null)
                return NotFound("Não encontrado");

            // #2 - Calcula o frete         
            // Nunca é menos que R$ 5,00
            var valor = await _deliveryFeeService.GetDeliveryFeeAsync(zipCode);

            // #4 - Aplica o cupom de desconto
            var cupon = await _promoCodeRepository.GetPromoCodeAsync(promoCode);
            var discount = cupon?.Value ?? 0M;

            // #3 - Calcula o total dos produtos
            // #5 - Gera o pedido
            // #6 - Calcula o total
            //(ele está gerando tudo dentro da classe Order)
            var order = new Order(valor, discount, new List<Product>());
            //não foi criado o repository, mas é nesse logica
            // #7 - Retorna
            return Ok(new
            {
                Message = $"Pedido {order.Code} gerado com sucesso!"
            });
        }
    }
}

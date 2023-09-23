using _01_Demo.Interface;
using _01_Demo.Models;

namespace _01_Demo.Services
{
    //Implementação Concreta
    // esse Cliente Service seja injetado na controller, pois existe uma dependencia 
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteService;
        public ClienteService(IClienteRepository clienteService)=> _clienteService = clienteService;
        public bool AdicionarCliente(Cliente cliente)
        {
            return(_clienteService.AdicionarCliente(cliente));
        }
    }
}

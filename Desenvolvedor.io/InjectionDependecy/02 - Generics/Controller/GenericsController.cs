using _01_Demo.Interface;
using _01_Demo.Models;
using _01_Demo.Repository;
using Microsoft.AspNetCore.Mvc;

namespace _01_Demo.Controller
{
    [ApiController]
    [Route("/")]
    public class GenericsController : ControllerBase
    {
        private readonly IGenericRepository<Cliente> _clienteService;
        public GenericsController(IGenericRepository<Cliente> clienteService)
        {
            _clienteService = clienteService;
        }
        [HttpGet]
        public IActionResult AdicionarCliente()
        {
            return Ok(_clienteService.AdicionarCliente(new Cliente()));
        }
    }
}

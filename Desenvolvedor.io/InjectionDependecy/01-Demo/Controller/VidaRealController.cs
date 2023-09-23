using _01_Demo.Interface;
using _01_Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace _01_Demo.Controller
{
    [ApiController]
    [Route("/")]
    public class VidaRealController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public VidaRealController(IClienteService clienteService)
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

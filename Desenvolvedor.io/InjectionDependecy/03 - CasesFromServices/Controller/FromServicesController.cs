using _01_Demo.Interface;
using _01_Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace _01_Demo.Controller
{
    [ApiController]
    [Route("/")]
    public class FromServicesController : ControllerBase
    {
        //você tem a opção de fazer a injeção de dependencia por parametro, mas não é recomendado, o recomendado é usar o construtor 
        //pq utilizar? - imagine que vc deve fazer uma grande refatoração da classe, mas vc n tem condição de mexer 
        //então vc injeta direto no metodo
        [HttpGet]
        public IActionResult AdicionarCliente([FromServices] IClienteService clienteService)
        {
            return Ok(clienteService.AdicionarCliente(new Cliente()));
        }
    }
}

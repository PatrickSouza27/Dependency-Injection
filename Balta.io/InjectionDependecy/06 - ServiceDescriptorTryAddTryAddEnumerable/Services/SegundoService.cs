namespace _05___MostrandoComoAcontece.Services
{
    public class SegundoService : IService
    {
        private PrimeiroService _PrimeiroService;
        public Guid SegundoGuid { get; set; } = Guid.NewGuid();
        public Guid Primeiro => _PrimeiroService.PrimeiroGuid;
        
        public SegundoService(PrimeiroService primeiroService)=> _PrimeiroService = primeiroService;
    }
}

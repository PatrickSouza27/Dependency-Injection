namespace _05___MostrandoComoAcontece.Services
{
    public class TerceiroService : IService
    {
        private PrimeiroService _PrimeiroService;
        private SegundoService _SegundoService;
        private SegundoService _SegundoServiceComNovaInstancia;
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid PrimeiroService => _PrimeiroService.PrimeiroGuid;
        public Guid SegundoService => _SegundoService.SegundoGuid;

        public Guid SegundoServiceComNovaInstancia => _SegundoServiceComNovaInstancia.SegundoGuid;

        public TerceiroService(PrimeiroService primeiroService, SegundoService segundoService, SegundoService segundocomnovaInstancia)
        {
            _PrimeiroService = primeiroService;
            _SegundoService = segundoService;
            _SegundoServiceComNovaInstancia = segundocomnovaInstancia;
        }
    }
}

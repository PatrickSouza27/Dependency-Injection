namespace _05___MostrandoComoAcontece.Services
{
    public class PrimeiroService : IService
    {
        public Guid PrimeiroGuid { get; set; } = Guid.NewGuid();
    }
}

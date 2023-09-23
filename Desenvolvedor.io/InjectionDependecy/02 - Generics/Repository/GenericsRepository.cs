using _01_Demo.Interface;
using _01_Demo.Models;

namespace _01_Demo.Repository
{
    public class GenericsRepository<T> : IGenericRepository<T> where T : class
    {
        public bool AdicionarCliente(T cliente)
        {
            // Faz algo
            return true;
        }
    }
}

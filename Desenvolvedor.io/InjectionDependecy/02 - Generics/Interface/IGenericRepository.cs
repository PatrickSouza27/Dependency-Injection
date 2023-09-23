using _01_Demo.Models;

namespace _01_Demo.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        bool AdicionarCliente(T cliente);
    }
}

using _01___Inicial.Models;

namespace _02___Resolvendo.Repository.Contracts
{
    public interface IPromoCodeRepository
    {
        Task<PromoCode?> GetPromoCodeAsync(string promoCode);
    }
}

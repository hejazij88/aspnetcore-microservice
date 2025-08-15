using Basket.Api.Entitys;

namespace Basket.Api.Repository;

public interface IBasketRepository
{
    Task<Cart?> GetCartAsync(string userName);
    Task<Cart?> UpdateCartAsync(Cart cart);
    Task DeleteCartAsync(string userName);
}
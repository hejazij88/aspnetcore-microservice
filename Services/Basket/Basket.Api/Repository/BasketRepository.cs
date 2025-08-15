using Basket.Api.Entitys;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.Api.Repository;

public class BasketRepository:IBasketRepository
{
    private readonly IDistributedCache _redis;

    public BasketRepository(IDistributedCache redis)
    {
        _redis = redis;
    }

    public async Task<Cart?> GetCartAsync(string userName)
    {
        var basket= await _redis.GetStringAsync(userName);
        if (basket == null) return null;
        return JsonConvert.DeserializeObject<Cart>(basket);
    }

    public async Task<Cart?> UpdateCartAsync(Cart cart)
    {
       await _redis.SetStringAsync(cart.UserName, JsonConvert.SerializeObject(cart));
       return await GetCartAsync(cart.UserName);

    }

    public async Task DeleteCartAsync(string userName)
    {
         await _redis.RemoveAsync(userName);
    }
}
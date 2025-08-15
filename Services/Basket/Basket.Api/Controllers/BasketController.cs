using System.Net;
using Basket.Api.Entitys;
using Basket.Api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;

namespace Basket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }



        [HttpGet]
        [ProducesResponseType(typeof(Cart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Cart>> GetCart(string userName)
        {
            var basket = await _basketRepository.GetCartAsync(userName);
            return Ok(basket ?? new Cart());
        }

        [HttpPost]
        [ProducesResponseType(typeof(Cart),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<Cart>> UpdateCart(Cart cart)
        {
            return Ok(await _basketRepository.UpdateCartAsync(cart));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket(string userName)
        {
            await _basketRepository.DeleteCartAsync(userName);
            return Ok();
        }



    }
}

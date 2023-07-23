using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CartController : ControllerBase
	{
		private readonly ICartSvc _cartSvc;

		public CartController(ICartSvc cartSvc)
        {
			_cartSvc = cartSvc;
		}

		[HttpPost("products")]
		public async Task<ActionResult<ServiceResponse<List<CartProductResponse>>>> GetCartProducts(List<CartItem> cartItems)
		{
			var result = await _cartSvc.GetCartProducts(cartItems);
			return Ok(result);
		}
    }
}

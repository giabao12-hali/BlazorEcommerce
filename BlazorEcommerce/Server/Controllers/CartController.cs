using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

		[HttpPost]
		public async Task<ActionResult<ServiceResponse<List<CartProductResponse>>>> StoreCartItems(List<CartItem> cartItems)
		{
			var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
			var result = await _cartSvc.StoreCartItems(cartItems);
			return Ok(result);
		}

		[HttpGet("count")]
		public async Task<ActionResult<ServiceResponse<int>>> GetCartItemsCount()
		{
			return await _cartSvc.GetCartItemsCount();
		}

		[HttpGet]
		public async Task<ActionResult<ServiceResponse<List<CartProductResponse>>>> GetDbCartProducts()
		{
			var result = await _cartSvc.GetDbCartProducts();
			return Ok(result);
		}
	}
}

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
			var result = await _cartSvc.StoreCartItems(cartItems);
			return Ok(result);
		}

		[HttpPost("add")]
		public async Task<ActionResult<ServiceResponse<bool>>> AddToCart(CartItem cartItem)
		{
			var result = await _cartSvc.AddToCartt(cartItem);
			return Ok(result);
		}

		[HttpPut("update-quantity")]
		public async Task<ActionResult<ServiceResponse<bool>>> UpdateQuantity(CartItem cartItem)
		{
			var result = await _cartSvc.UpdateQuantity(cartItem);
			return Ok(result);
		}

		[HttpDelete("{productId}/{productTypeId}")]
		public async Task<ActionResult<ServiceResponse<bool>>> RemoveItemFromCart(int productId, int productTypeId)
		{
			var result = await _cartSvc.RemoveItemFromCart(productId, productTypeId);
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

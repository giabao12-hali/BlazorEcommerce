using BlazorEcommerce.Server.Services.OrderSvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly IOrderSvc _orderSvc;

		public OrderController(IOrderSvc orderSvc)
        {
			_orderSvc = orderSvc;
		}

		[HttpGet]
		public async Task<ActionResult<ServiceResponse<List<OrderOverviewResponse>>>> GetOrders()
		{
			var result = await _orderSvc.GetOrders();
			return Ok(result);
		}

		[HttpGet("{orderId}")]
		public async Task<ActionResult<ServiceResponse<OrderDetailsResponse>>> GetOrdersDetails(int orderId)
		{
			var result = await _orderSvc.GetOrderDetails(orderId);
			return Ok(result);
		}
	}
}

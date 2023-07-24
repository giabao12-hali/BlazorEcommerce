using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PaymentController : ControllerBase
	{
		private readonly IPaymentSvc _paymentSvc;

		public PaymentController(IPaymentSvc paymentSvc)
        {
			_paymentSvc = paymentSvc;
		}

		[HttpPost("checkout"), Authorize]
		public async Task<ActionResult<string>> CreateCheckoutSession()
		{
			var session = await _paymentSvc.CreateCheckoutSession();
			return Ok(session.Url);
		}

		[HttpPost]
		public async Task<ActionResult<ServiceResponse<bool>>> FulfilOrder()
		{
			var response = await _paymentSvc.FulfilOrder(Request);
			if (!response.Success)
			{
				return BadRequest(response.Message);
			}
			return Ok(response);
		}
	}
}

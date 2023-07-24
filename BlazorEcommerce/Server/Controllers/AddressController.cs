using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class AddressController : ControllerBase
	{
		private readonly IAddressSvc _addressSvc;

		public AddressController(IAddressSvc addressSvc)
        {
			_addressSvc = addressSvc;
		}

		[HttpGet]
		public async Task<ActionResult<ServiceResponse<Address>>> GetAddress()
		{
			return await _addressSvc.GetAddress();
		}

		[HttpPost]
		public async Task<ActionResult<ServiceResponse<Address>>> AddOrUpdateAddress(Address address)
		{
			return await _addressSvc.AddOrUpdateAddress(address);
		}
	}
}

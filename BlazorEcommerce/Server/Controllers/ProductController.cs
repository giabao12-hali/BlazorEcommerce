using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductSvc _productSvc;

		public ProductController(IProductSvc productSvc)
        {
			_productSvc = productSvc;
		}

        [HttpGet]
		public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
		{
			var result = await _productSvc.GetProductsAsync();
			return Ok(result);
		}

		[HttpGet("{productId}")]
		public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProduct(int productId)
		{
			var result = await _productSvc.GetSingleProduct(productId);
			return Ok(result);
		}

	}
}

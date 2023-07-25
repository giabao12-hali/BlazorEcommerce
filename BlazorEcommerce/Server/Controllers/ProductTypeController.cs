using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeSvc _productTypeSvc;

        public ProductTypeController(IProductTypeSvc productTypeSvc)
        {
            _productTypeSvc = productTypeSvc;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ProductType>>>> GetProductTypes()
        {
            var response = await _productTypeSvc.GetProductTypes();
            return Ok(response);
        }

		[HttpPost]
		public async Task<ActionResult<ServiceResponse<List<ProductType>>>> AddProductTypes(ProductType productType)
		{
			var response = await _productTypeSvc.AddProductType(productType);
			return Ok(response);
		}

		[HttpPut]
		public async Task<ActionResult<ServiceResponse<List<ProductType>>>> UpdateProductTypes(ProductType productType)
		{
			var response = await _productTypeSvc.UpdateProductType(productType);
			return Ok(response);
		}
	}
}

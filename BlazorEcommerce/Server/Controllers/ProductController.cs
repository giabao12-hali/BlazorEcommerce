﻿using Microsoft.AspNetCore.Http;
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
		public async Task<ActionResult<ServiceResponse<Product>>> GetProduct(int productId)
		{
			var result = await _productSvc.GetSingleProduct(productId);
			return Ok(result);
		}

		[HttpGet("category/{categoryUrl}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsByCategory(string categoryUrl)
        {
            var result = await _productSvc.GetProductsByCategory(categoryUrl);
            return Ok(result);
        }

		[HttpGet("search/{searchText}/{page}")]
		public async Task<ActionResult<ServiceResponse<ProductSearchResult>>> SearchProducts(string searchText, int page = 1)
		{
			var result = await _productSvc.SearchProducts(searchText, page);
			return Ok(result);
		}

		[HttpGet("searchsuggestions/{searchText}")]
		public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductSearchSuggestions(string searchText)
		{
			var result = await _productSvc.GetProductSearchSuggestions(searchText);
			return Ok(result);
		}

		[HttpGet("featured")]
		public async Task<ActionResult<ServiceResponse<List<Product>>>> GetFeaturedProducts()
		{
			var result = await _productSvc.GetFeaturedProducts();
			return Ok(result);
		}
	}
}

﻿namespace BlazorEcommerce.Server.Services.ProductSvc
{
	public class ProductSvc : IProductSvc
	{
		private readonly DataContext _context;

		public ProductSvc(DataContext context)
        {
			_context = context;
		}

		public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
		{
			var response = new ServiceResponse<List<Product>>
			{
				Data = await _context.Products.ToListAsync()
			};

			return response;
		}

		public async Task<ServiceResponse<Product>> GetSingleProduct(int productId)
		{
			var response = new ServiceResponse<Product>();
			var product = await _context.Products.FindAsync(productId);
			if(product == null)
			{
				response.Success = false;
				response.Message = "Sorry, but this product does not exist";
			}
			else
			{
				response.Data = product;
			}
			return response;
		}
	}
}

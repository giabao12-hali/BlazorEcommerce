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
				Data = await _context.Products.Include(p => p.Variants).ToListAsync()
			};

			return response;
		}

        public async Task<ServiceResponse<Product>> GetSingleProduct(int productId)
		{
			var response = new ServiceResponse<Product>();
			var product = await _context.Products
				.Include(p => p.Variants)
				.ThenInclude(v => v.ProductType)
				.FirstOrDefaultAsync(p => p.Id == productId);
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

        public async Task<ServiceResponse<List<Product>>> GetProductsByCategory(string categoryUrl)
        {
            var response = new ServiceResponse<List<Product>>
			{ 
				Data = await _context.Products
					.Where(p => p.Category.Url.ToLower().Equals(categoryUrl.ToLower()))
					.Include(p => p.Variants)
					.ToListAsync()
			};
			return response;
        }

		public async Task<ServiceResponse<List<Product>>> SearchProducts(string searchText)
		{
			var response = new ServiceResponse<List<Product>>
			{
				Data = await _context.Products
					.Where(p => p.Title.ToLower().Contains(searchText.ToLower())
					|| p.Description.ToLower().Contains(searchText.ToLower()))
					.Include(p => p.Variants)
					.ToListAsync()
			};
			return response;
		}
	}
}

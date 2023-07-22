﻿using System.Reflection.Metadata.Ecma335;

namespace BlazorEcommerce.Server.Services.ProductSvc
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

		public async Task<ServiceResponse<ProductSearchResult>> SearchProducts(string searchText, int page)
		{
			var pageResults = 2f;
			var pageCount = Math.Ceiling((await FindProductBySearchText(searchText)).Count / pageResults);
			var products = await _context.Products
								.Where(p => p.Title.ToLower().Contains(searchText.ToLower())
								|| p.Description.ToLower().Contains(searchText.ToLower()))
								.Include(p => p.Variants)
								.Skip((page - 1) * (int)pageResults)
								.Take((int)pageResults)
								.ToListAsync();

			var response = new ServiceResponse<ProductSearchResult>
			{
				Data = new ProductSearchResult
				{
					Products = products,
					CurrentPage = page,
					Pages = (int)pageCount
				}
			};
			return response;
		}

		private async Task<List<Product>> FindProductBySearchText(string searchText)
		{
			return await _context.Products
								.Where(p => p.Title.ToLower().Contains(searchText.ToLower())
								|| p.Description.ToLower().Contains(searchText.ToLower()))
								.Include(p => p.Variants)
								.ToListAsync();
		}

		public async Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText)
		{
			var products = await FindProductBySearchText(searchText);

			List<string> result = new List<string>();

			foreach (var product in products)
			{
				if(product.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase))
				{
					result.Add(product.Title);
				}

				if(product.Description != null)
				{
					var punctuation = product.Description.Where(char.IsPunctuation)
						.Distinct().ToArray();
					var words = product.Description.Split()
						.Select(s => s.Trim(punctuation));

                    foreach (var word in words)
                    {
                        if(word.Contains(searchText, StringComparison.OrdinalIgnoreCase)
							&& !result.Contains(word))
						{
							result.Add(word);
						}
                    }
                }
			}

			return new ServiceResponse<List<string>>
			{
				Data = result
			};
		}

		public async Task<ServiceResponse<List<Product>>> GetFeaturedProducts()
		{
			var response = new ServiceResponse<List<Product>>
			{
				Data = await _context.Products
					.Where(p => p.Featured)
					.Include(p => p.Variants)
					.ToListAsync()
			};
			return response;
		}
	}
}

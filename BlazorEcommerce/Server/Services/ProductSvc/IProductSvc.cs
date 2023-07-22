namespace BlazorEcommerce.Server.Services.ProductSvc
{
	public interface IProductSvc
	{
		Task<ServiceResponse<List<Product>>> GetProductsAsync();
		Task<ServiceResponse<Product>> GetSingleProduct(int productId);
        Task<ServiceResponse<List<Product>>> GetProductsByCategory(string categoryUrl);
		Task<ServiceResponse<ProductSearchResult>> SearchProducts(string searchText, int page);
		Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText);		
		Task<ServiceResponse<List<Product>>> GetFeaturedProducts();

	}
}

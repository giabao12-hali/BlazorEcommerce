namespace BlazorEcommerce.Server.Services.ProductSvc
{
	public interface IProductSvc
	{
		Task<ServiceResponse<List<Product>>> GetProductsAsync();
		Task<ServiceResponse<Product>> GetSingleProduct(int productId);
        Task<ServiceResponse<List<Product>>> GetProductsByCategory(string categoryUrl);
		Task<ServiceResponse<List<Product>>> SearchProducts(string searchText);
		Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText);
    }
}

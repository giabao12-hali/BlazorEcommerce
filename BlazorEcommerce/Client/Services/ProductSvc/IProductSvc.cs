namespace BlazorEcommerce.Client.Services.ProductSvc
{
	public interface IProductSvc
	{
		event Action ProductChanged;
		List<Product> Products { get; set; }
		string Message { get; set; }
		Task GetProducts(string? categoryUrl = null);
		Task<ServiceResponse<Product>> GetSingleProduct(int productId);
		Task SearchProducts(string searchText);
		Task<List<string>> GetProductSearchSuggestions(string searchText);
	}
}

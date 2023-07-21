namespace BlazorEcommerce.Server.Services.ProductSvc
{
	public interface IProductSvc
	{
		Task<ServiceResponse<List<Product>>> GetProductsAsync();
		Task<ServiceResponse<Product>> GetSingleProduct(int productId);
	}
}

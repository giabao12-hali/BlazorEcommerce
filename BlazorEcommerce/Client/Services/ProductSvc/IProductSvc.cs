namespace BlazorEcommerce.Client.Services.ProductSvc
{
	public interface IProductSvc
	{
		List<Product> Products { get; set; }
		Task GetProducts();
		Task<ServiceResponse<Product>> GetSingleProduct(int productId);
	}
}

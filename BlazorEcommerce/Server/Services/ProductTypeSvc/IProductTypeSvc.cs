namespace BlazorEcommerce.Server.Services.ProductTypeSvc
{
    public interface IProductTypeSvc
    {
        Task<ServiceResponse<List<ProductType>>> GetProductTypes();
        Task<ServiceResponse<List<ProductType>>> AddProductType(ProductType productType);
        Task<ServiceResponse<List<ProductType>>> UpdateProductType(ProductType productType);
	}
}

namespace BlazorEcommerce.Server.Services.CategorySvc
{
	public interface ICategorySvc
	{
		Task<ServiceResponse<List<Category>>> GetCategories();
	}
}

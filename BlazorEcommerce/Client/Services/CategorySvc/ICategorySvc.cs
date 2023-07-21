namespace BlazorEcommerce.Client.Services.CategorySvc
{
	public interface ICategorySvc
	{
		List<Category> Categories { get; set; }
		Task GetCategories();
	}
}

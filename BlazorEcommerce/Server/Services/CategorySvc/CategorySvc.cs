namespace BlazorEcommerce.Server.Services.CategorySvc
{
	public class CategorySvc : ICategorySvc
	{
		private readonly DataContext _context;

		public CategorySvc(DataContext context)
        {
			_context = context;
		}
        public async Task<ServiceResponse<List<Category>>> GetCategories()
		{
			var categories = await _context.Categories.ToListAsync();
			return new ServiceResponse<List<Category>>
			{ 
				Data = categories 
			};
		}
	}
}

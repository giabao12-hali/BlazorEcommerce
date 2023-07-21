namespace BlazorEcommerce.Client.Services.CategorySvc
{
	public class CategorySvc : ICategorySvc
	{
		private readonly HttpClient _httpClient;

		public CategorySvc(HttpClient httpClient)
        {
			_httpClient = httpClient;
		}
        public List<Category> Categories { get; set ; } = new List<Category>();

		public async Task GetCategories()
		{
			var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/category");
			if(response != null && response.Data != null)
				Categories = response.Data;
		}
	}
}

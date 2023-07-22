namespace BlazorEcommerce.Client.Services.ProductSvc
{
	public class ProductSvc : IProductSvc
	{
		private readonly HttpClient _httpClient;

		public ProductSvc(HttpClient httpClient)
        {
			_httpClient = httpClient;
		}
        public List<Product> Products { get; set; } = new List<Product>();
		public string Message { get; set; } = "Loading products...";

		public event Action ProductChanged;

        public async Task<ServiceResponse<Product>> GetSingleProduct(int productId)
		{
			var result = await _httpClient.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{productId}");
			return result;
		}

        public async Task GetProducts(string? categoryUrl = null)
		{
			var result = categoryUrl == null ? 
				await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product/featured") :
                await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/category/{categoryUrl}");
			if (result != null && result.Data != null)
				Products = result.Data;

			ProductChanged.Invoke();
		}

		public async Task<List<string>> GetProductSearchSuggestions(string searchText)
		{
			var result = await _httpClient.
				GetFromJsonAsync<ServiceResponse<List<string>>>($"api/product/searchsuggestions/{searchText}");
			return result.Data;
		}
		public async Task SearchProducts(string searchText)
		{
			var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/search/{searchText}");
			if(result != null && result.Data != null)
			{
				Products = result.Data;
			}
			if (Products.Count == 0) Message = "No products found.";
			ProductChanged?.Invoke();
		}
	}
}

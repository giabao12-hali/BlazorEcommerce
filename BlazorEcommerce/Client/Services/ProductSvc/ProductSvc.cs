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

		public async Task GetProducts()
		{
			var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product");
			if (result != null && result.Data != null)
				Products = result.Data;
		}

		public async Task<ServiceResponse<Product>> GetSingleProduct(int productId)
		{
			var result = await _httpClient.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{productId}");
			return result;
		}
	}
}

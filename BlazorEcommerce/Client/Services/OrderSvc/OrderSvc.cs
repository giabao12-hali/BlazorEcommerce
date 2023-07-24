using Microsoft.AspNetCore.Components;

namespace BlazorEcommerce.Client.Services.OrderSvc
{
	public class OrderSvc : IOrderSvc
	{
		private readonly HttpClient _httpClient;
		private readonly AuthenticationStateProvider _authStateProvider;
		private readonly AuthenticationStateProvider _authenticationStateProvider;
		private readonly NavigationManager _navigationManager;

		public OrderSvc(HttpClient httpClient,
			AuthenticationStateProvider authStateProvider,
			NavigationManager navigationManager)
        {
			_httpClient = httpClient;
			_authStateProvider = authStateProvider;
			_navigationManager = navigationManager;
		}
		private async Task<bool> IsUserAuthenticated()
		{
			return (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
		}
		public async Task PlaceOrder()
		{
			if(await IsUserAuthenticated())
			{
				await _httpClient.PostAsync("api/order", null);
			}
			else
			{
				_navigationManager.NavigateTo("login");
			}
		}

		public async Task<List<OrderOverviewResponse>> GetOrders()
		{
			var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<OrderOverviewResponse>>>("api/order");
			return result.Data;
		}

		public async Task<OrderDetailsResponse> GetOrderDetails(int orderId)
		{
			var result = await _httpClient.GetFromJsonAsync<ServiceResponse<OrderDetailsResponse>>($"api/order/{orderId}");
			return result.Data;
		}
	}
}

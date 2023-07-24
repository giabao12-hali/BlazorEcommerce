namespace BlazorEcommerce.Client.Services.AuthSvc
{
	public class AuthSvc : IAuthSvc
	{
		private readonly HttpClient _httpClient;
		private readonly AuthenticationStateProvider _authStateProvider;

		public AuthSvc(HttpClient httpClient, AuthenticationStateProvider authStateProvider)
        {
			_httpClient = httpClient;
			_authStateProvider = authStateProvider;
		}

		public async Task<ServiceResponse<bool>> ChangePassword(UserChangePassword request)
		{
			var result = await _httpClient.PostAsJsonAsync("api/auth/change-password", request.Password);
			return await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
		}

		public async Task<bool> IsUserAuthenticated()
		{
			return (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
		}

		public async Task<ServiceResponse<string>> Login(UserLogin request)
		{
			var result = await _httpClient.PostAsJsonAsync("api/auth/login", request);
			return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
		}

		public async Task<ServiceResponse<int>> Register(UserRegister request)
		{
			var result = await _httpClient.PostAsJsonAsync("api/auth/register", request);
			return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
		}
	}
}

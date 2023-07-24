namespace BlazorEcommerce.Client.Services.AuthSvc
{
	public class AuthSvc : IAuthSvc
	{
		private readonly HttpClient _httpClient;

		public AuthSvc(HttpClient httpClient)
        {
			_httpClient = httpClient;
		}

		public async Task<ServiceResponse<bool>> ChangePassword(UserChangePassword request)
		{
			var result = await _httpClient.PostAsJsonAsync("api/auth/change-password", request.Password);
			return await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
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

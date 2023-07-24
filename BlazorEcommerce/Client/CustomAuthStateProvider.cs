using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace BlazorEcommerce.Client
{
	public class CustomAuthStateProvider : AuthenticationStateProvider
	{
		private readonly ILocalStorageService _localStorage;
		private readonly HttpClient _httpClient;

		public CustomAuthStateProvider(ILocalStorageService localStorage, HttpClient httpClient)
        {
			_localStorage = localStorage;
			_httpClient = httpClient;
		}
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			string authToken = await _localStorage.GetItemAsStringAsync("authToken");

			//nếu như không có authToken, thì mình sẽ tạo một cái empty ClaimsIdentity
			//bằng default để biết là người dùng chưa author
			var identity = new ClaimsIdentity();
			_httpClient.DefaultRequestHeaders.Authorization = null;
			//

			if (!string.IsNullOrEmpty(authToken))
			{
				try
				{
					identity = new ClaimsIdentity(ParseClaimsFromJwt(authToken), "jwt");
					_httpClient.DefaultRequestHeaders.Authorization =
						new AuthenticationHeaderValue("Bearer", authToken.Replace("\"",""));
				}
				catch
				{
					await _localStorage.RemoveItemAsync("authToken");
					identity = new ClaimsIdentity();
				}
			}

			var user = new ClaimsPrincipal(identity);
			var state = new AuthenticationState(user);

			NotifyAuthenticationStateChanged(Task.FromResult(state));

			return state;
		}

		private byte[] ParseBase64WithoutPadding(string base64)
		{
			switch (base64.Length % 4)
			{
				case 2: base64 += "==";
					break;
				case 3: base64 += "=";
					break;
			}
			return Convert.FromBase64String(base64);
		}

		private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
		{
			var payload = jwt.Split('.')[1];
			var jsonBytes = ParseBase64WithoutPadding(payload);
			var keyValuePairs = JsonSerializer
				.Deserialize<Dictionary<string, object>>(jsonBytes);
			var claims = keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));

			return claims;
		}
	}
}

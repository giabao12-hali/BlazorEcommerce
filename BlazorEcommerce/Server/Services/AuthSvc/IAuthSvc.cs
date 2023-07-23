namespace BlazorEcommerce.Server.Services.AuthSvc
{
	public interface IAuthSvc
	{
		Task<ServiceResponse<int>> Register(User user, string password);
		Task<bool> UserExist(string email);
		Task<ServiceResponse<string>> Login(string email, string password);
	}
}

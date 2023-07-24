namespace BlazorEcommerce.Client.Services.AuthSvc
{
	public interface IAuthSvc
	{
		Task<ServiceResponse<int>> Register(UserRegister request);
		Task<ServiceResponse<string>> Login(UserLogin request);
		Task<ServiceResponse<bool>> ChangePassword(UserChangePassword request);
		Task<bool> IsUserAuthenticated();
	}
}

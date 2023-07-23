namespace BlazorEcommerce.Client.Services.AuthSvc
{
	public interface IAuthSvc
	{
		Task<ServiceResponse<int>> Register(UserRegister request);
	}
}

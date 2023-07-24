namespace BlazorEcommerce.Server.Services.AddressSvc
{
	public interface IAddressSvc
	{
		Task<ServiceResponse<Address>> GetAddress();
		Task<ServiceResponse<Address>> AddOrUpdateAddress(Address address);
	}
}

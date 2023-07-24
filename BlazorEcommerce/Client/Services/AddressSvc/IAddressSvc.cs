namespace BlazorEcommerce.Client.Services.AddressSvc
{
	public interface IAddressSvc
	{
		Task<Address> GetAddress();
		Task<Address> AddOrUpdateAddress(Address address);
	}
}

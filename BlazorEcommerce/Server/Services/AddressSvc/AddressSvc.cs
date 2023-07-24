namespace BlazorEcommerce.Server.Services.AddressSvc
{
	public class AddressSvc : IAddressSvc
	{
		private readonly DataContext _context;
		private readonly IAuthSvc _authSvc;

		public AddressSvc(DataContext context, IAuthSvc authSvc)
        {
			_context = context;
			_authSvc = authSvc;
		}

        public async Task<ServiceResponse<Address>> AddOrUpdateAddress(Address address)
		{
			var response = new ServiceResponse<Address>();
			var dbAddress = (await GetAddress()).Data;
			if(dbAddress == null)
			{
				address.UserId = _authSvc.GetUserId();
				_context.Addresses.Add(address);
				response.Data = address;
			}
			else
			{
				dbAddress.FirstName = address.FirstName;
				dbAddress.LastName = address.LastName;
				dbAddress.State = address.State;
				dbAddress.Country = address.Country;
				dbAddress.City = address.City;
				dbAddress.Zip = address.Zip;
				dbAddress.Street = address.Street;
				response.Data = dbAddress;
			}

			await _context.SaveChangesAsync();
			return response;
		}

		public async Task<ServiceResponse<Address>> GetAddress()
		{
			int userId = _authSvc.GetUserId();
			var address = await _context.Addresses.FirstOrDefaultAsync(a => a.UserId == userId);
			return new ServiceResponse<Address>
			{
				Data = address
			};
		}
	}
}

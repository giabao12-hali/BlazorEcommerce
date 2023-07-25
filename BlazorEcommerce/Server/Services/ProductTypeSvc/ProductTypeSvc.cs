using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Server.Services.ProductTypeSvc
{
    public class ProductTypeSvc : IProductTypeSvc
    {
        private readonly DataContext _context;

        public ProductTypeSvc(DataContext context)
        {
            _context = context;
        }

		public async Task<ServiceResponse<List<ProductType>>> AddProductType(ProductType productType)
		{
			productType.Editing = productType.IsNew = false;
			_context.ProductTypes.Add(productType);
            await _context.SaveChangesAsync();

            return await GetProductTypes();
		}

		public async Task<ServiceResponse<List<ProductType>>> GetProductTypes()
        {
            var productTypes = await _context.ProductTypes.ToListAsync();
            return new ServiceResponse<List<ProductType>>
            {
                Data = productTypes
            };
        }

		public async Task<ServiceResponse<List<ProductType>>> UpdateProductType(ProductType productType)
		{
			var dbProductTypes = await _context.ProductTypes.FindAsync(productType.Id);
            if(dbProductTypes == null)
            {
                return new ServiceResponse<List<ProductType>>
                {
                    Success = false,
                    Message = "Product Type not found."
                };
            }

            dbProductTypes.Name = productType.Name;
            await _context.SaveChangesAsync();

            return await GetProductTypes();
		}
	}
}

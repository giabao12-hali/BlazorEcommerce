namespace BlazorEcommerce.Server.Services.CartSvc
{
	public interface ICartSvc
	{
		Task<ServiceResponse<List<CartProductResponse>>> GetCartProducts(List<CartItem> cartItems);
		Task<ServiceResponse<List<CartProductResponse>>> StoreCartItems(List<CartItem> cartItems);
		Task<ServiceResponse<int>> GetCartItemsCount();
		Task<ServiceResponse<List<CartProductResponse>>> GetDbCartProducts();	
	}
}

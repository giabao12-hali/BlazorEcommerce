namespace BlazorEcommerce.Client.Services.CartSvc
{
	public interface ICartSvc
	{
		event Action OnChange;
		Task AddToCart(CartItem cartItem);
		Task<List<CartItem>> GetCartItems();
		Task<List<CartProductResponse>> GetCartProducts();
		Task RemoveProductFromCart(int productId, int productTypeId);
		Task UpdateQuantity(CartProductResponse product);
		Task StoreCartItems(bool emptyLocalCart);
	}
}

namespace BlazorEcommerce.Client.Services.CartSvc
{
	public interface ICartSvc
	{
		event Action OnChange;
		Task AddToCart(CartItem cartItem);
		Task<List<CartItem>> GetCartItems();
	}
}

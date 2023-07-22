using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client.Services.CartSvc
{
	public class CartSvc : ICartSvc
	{
		private readonly ILocalStorageService _localStorage;

		public CartSvc(ILocalStorageService localStorage)
        {
			_localStorage = localStorage;
		}

        public event Action OnChange;

		public async Task AddToCart(CartItem cartItem)
		{
			var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
			if (cart == null)
			{
				cart = new List<CartItem>();
			}
			cart.Add(cartItem);

			await _localStorage.SetItemAsync("cart", cart);
		}

		public async Task<List<CartItem>> GetCartItems()
		{
			var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
			if (cart == null)
			{
				cart = new List<CartItem>();
			}
			return cart;
		}
	}
}

using Stripe;
using Stripe.Checkout;

namespace BlazorEcommerce.Server.Services.PaymentSvc
{
	public class PaymentSvc : IPaymentSvc
	{
		private readonly ICartSvc _cartSvc;
		private readonly IAuthSvc _authSvc;
		private readonly IOrderSvc _orderSvc;
  
		const string secret = "..."; // Replace your Secret Key

		public PaymentSvc(ICartSvc cartSvc,
			IAuthSvc authSvc,
			IOrderSvc orderSvc)
        {
			StripeConfiguration.ApiKey = "..."; // Replace your API Stripe Key

			_cartSvc = cartSvc;
			_authSvc = authSvc;
			_orderSvc = orderSvc;
		}
        public async Task<Session> CreateCheckoutSession()
		{
			var products = (await _cartSvc.GetDbCartProducts()).Data;
			var lineItems = new List<SessionLineItemOptions>();
			products.ForEach(product => lineItems.Add(new SessionLineItemOptions
			{
				PriceData = new SessionLineItemPriceDataOptions
				{
					UnitAmountDecimal = product.Price * 100,
					Currency = "usd",
					ProductData = new SessionLineItemPriceDataProductDataOptions
					{
						Name = product.Title,
						Images = new List<string>
						{
							product.ImageUrl
						}
					}
				},
				Quantity = product.Quantity
			}));

			var options = new SessionCreateOptions
			{
				CustomerEmail = _authSvc.GetUserEmail(),
				ShippingAddressCollection =
				//add địa chỉ trong lúc thanh toán
				new SessionShippingAddressCollectionOptions
				{
					AllowedCountries = new List<string> { "US" }
				},
				//
				PaymentMethodTypes = new List<string>
				{
					"card"
				},
				LineItems = lineItems,
				Mode = "payment",
				SuccessUrl = "https://localhost:7205/order-success", // Replace your URL
				CancelUrl = "https://localhost:7205/cart" // Replace your URL
			};

			var service = new SessionService();
			Session session = service.Create(options);
			return session;
		}

		public async Task<ServiceResponse<bool>> FulfilOrder(HttpRequest request)
		{
			var json = await new StreamReader(request.Body).ReadToEndAsync();
			try
			{
				var stripeEvent = EventUtility.ConstructEvent(
						json,
						request.Headers["Stripe-Signature"],
						secret
					);

				if(stripeEvent.Type == Events.CheckoutSessionCompleted)
				{
					var session = stripeEvent.Data.Object as Session;
					var user = await _authSvc.GetUserByEmail(session.CustomerEmail);
					await _orderSvc.PlaceOrder(user.Id);
				}

				return new ServiceResponse<bool>
				{
					Data = true
				};
			}
			catch(StripeException e)
			{
				return new ServiceResponse<bool>
				{
					Data = false,
					Success = false,
					Message = e.Message
				};
			}
		}
	}
}

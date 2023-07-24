using Stripe.Checkout;

namespace BlazorEcommerce.Server.Services.PaymentSvc
{
	public interface IPaymentSvc
	{
		Task<Session> CreateCheckoutSession();
		Task<ServiceResponse<bool>> FulfilOrder(HttpRequest request);
	}
}

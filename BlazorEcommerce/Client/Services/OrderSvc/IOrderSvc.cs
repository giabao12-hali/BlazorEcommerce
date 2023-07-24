namespace BlazorEcommerce.Client.Services.OrderSvc
{
	public interface IOrderSvc
	{
		Task<string> PlaceOrder();
		Task<List<OrderOverviewResponse>> GetOrders();
		Task<OrderDetailsResponse> GetOrderDetails(int orderId);
	}
}

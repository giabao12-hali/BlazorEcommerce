namespace BlazorEcommerce.Client.Services.OrderSvc
{
	public interface IOrderSvc
	{
		Task PlaceOrder();
		Task<List<OrderOverviewResponse>> GetOrders();
		Task<OrderDetailsResponse> GetOrderDetails(int orderId);
	}
}

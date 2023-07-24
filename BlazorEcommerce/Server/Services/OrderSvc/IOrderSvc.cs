namespace BlazorEcommerce.Server.Services.OrderSvc
{
	public interface IOrderSvc
	{
		Task<ServiceResponse<bool>> PlaceOrder(int userId);
		Task<ServiceResponse<List<OrderOverviewResponse>>> GetOrders();
		Task<ServiceResponse<OrderDetailsResponse>> GetOrderDetails(int orderId);
	}
}

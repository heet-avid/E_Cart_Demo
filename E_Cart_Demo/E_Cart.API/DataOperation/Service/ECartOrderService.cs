using ECart.API.Data.Models;
using ECart.API.DataOperation.Interface;
using ECart.API.Repository.Interface;

namespace ECart.API.DataOperation.Service;
public class ECartOrderService : IECartOrderService
{
    private readonly IECartOrderRepository _order;

    public ECartOrderService(IECartOrderRepository order)
    {
        _order = order;
    }

    public Task<ApiResult> CreateOrder(ECartOrderModel model)
    {
        return _order.CreateOrder(model);
    }

    public Task<ApiResult<List<ECartOrderItemModel>>> GetOrderDetails(int id)
    {
        return _order.GetOrderDetails(id);
    }

    public Task<ApiResult<List<ECartOrderModel>>> GetOrders(int userId)
    {
        return _order.GetOrders(userId);
    }
}

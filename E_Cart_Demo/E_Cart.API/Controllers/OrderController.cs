using ECart.API.Data.Models;
using ECart.API.DataOperation.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECart.API.Controllers
{
    [Route("api/")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IECartOrderService _order;

        public OrderController(IECartOrderService orderService)
        {
            _order = orderService;
        }

        [HttpPost]
        [Route("orders")]
        public async Task<ApiResult> CreateOrder(ECartOrderModel model)
        {
            return await _order.CreateOrder(model);
        }

        [HttpGet]
        [Route("orders")]
        public async Task<ApiResult<List<ECartOrderModel>>> GetOrders(int userId)
        {
            return await _order.GetOrders(userId);
        }

        [HttpGet]
        [Route("orders/{id}")]
        public async Task<ApiResult<List<ECartOrderItemModel>>> GetOrderDetails(int id)
        {
            return await _order.GetOrderDetails(id);
        }
    }

}

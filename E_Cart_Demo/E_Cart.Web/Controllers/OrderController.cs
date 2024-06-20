using Microsoft.AspNetCore.Mvc;
using ECart.Web.Utility;
using ECart.Web.Models;

namespace ECart.Web.Controllers;

[Session]
public class OrderController : Controller
{
    private readonly IUtilityHelper _apiHelper;
    public OrderController(IUtilityHelper apiHelper)
    {
        _apiHelper = apiHelper;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<APIResponse<List<OrderModel>>> GetOrders()
    {
        var userId = HttpContext.Session.GetInt32("_SessionUserId");
        var responseMessage = await _apiHelper.MakeApiCallAsync("orders?userId=" + userId, HttpMethod.Get, HttpContext, null);
        var responseAsync = await UtilityMethod.ConvertApiResponseAsync<List<OrderModel>>(responseMessage);
        return responseAsync;
    }

    [HttpPost]
    public async Task<APIResponse<List<OrderItemModel>>> GetOrderDetails([FromBody] OrderModel model)
    {
        var responseMessage = await _apiHelper.MakeApiCallAsync("orders/" + model.Id, HttpMethod.Get, HttpContext, null);
        var responseAsync = await UtilityMethod.ConvertApiResponseAsync<List<OrderItemModel>>(responseMessage);
        return responseAsync;
    }

    [HttpPost]
    public async Task<APIResponse<string>> CreateOrder([FromBody] OrderModel model)
    {
        model.Status = Enum.GetName(OrderStatus.Pending);
        model.UserId = HttpContext.Session.GetInt32("_SessionUserId").Value;
        var responseMessage = await _apiHelper.MakeApiCallAsync("orders", HttpMethod.Post, HttpContext, model);
        var responseAsync = await UtilityMethod.ConvertApiResponseAsync<string>(responseMessage);
        return responseAsync;
    }
}
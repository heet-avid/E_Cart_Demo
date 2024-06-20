using ECart.Web.Utility;
using ECart.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECart.Web.Controllers;

[Session]
public class ProductController : Controller
{
    private readonly IUtilityHelper _apiHelper;
    public ProductController(IUtilityHelper apiHelper)
    {
        _apiHelper = apiHelper;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<APIResponse<List<ProductModel>>> GetProducts()
    {
        var responseMessage = await _apiHelper.MakeApiCallAsync("products", HttpMethod.Get, HttpContext, null);
        var responseAsync = await UtilityMethod.ConvertApiResponseAsync<List<ProductModel>>(responseMessage);
        return responseAsync;
    }

    [HttpPost]
    public async Task<APIResponse<string>> CreateProduct([FromBody] ProductModel model)
    {
        model.UserId = HttpContext.Session.GetInt32("_SessionUserId");
        var responseMessage = await _apiHelper.MakeApiCallAsync("products", HttpMethod.Post, HttpContext, model);
        var responseAsync = await UtilityMethod.ConvertApiResponseAsync<string>(responseMessage);
        return responseAsync;
    }

    [HttpPost]
    public async Task<APIResponse<string>> EditProduct([FromBody] ProductModel model)
    {
        model.UserId = HttpContext.Session.GetInt32("_SessionUserId");
        var responseMessage = await _apiHelper.MakeApiCallAsync("products/"+ model.Id, HttpMethod.Put, HttpContext, model);
        var responseAsync = await UtilityMethod.ConvertApiResponseAsync<string>(responseMessage);
        return responseAsync;
    }

    [HttpPost]
    public async Task<APIResponse<string>> DeleteProduct([FromBody] ProductModel model)
    {
        model.UserId = HttpContext.Session.GetInt32("_SessionUserId");
        var responseMessage = await _apiHelper.MakeApiCallAsync("products/"+ model.Id + "?userId="+ model.UserId, HttpMethod.Delete, HttpContext, null);
        var responseAsync = await UtilityMethod.ConvertApiResponseAsync<string>(responseMessage);
        return responseAsync;
    }
}

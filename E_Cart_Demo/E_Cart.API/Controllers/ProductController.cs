using ECart.API.Data.Models;
using ECart.API.DataOperation.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECart.API.Controllers;

[Route("api/")]
[ApiController]
[Authorize]
public class ProductController : ControllerBase
{
    private readonly IECartProductService _product;
    public ProductController(IECartProductService productService)
    {
        _product = productService;
    }

    [HttpGet]
    [Route("products")]
    public async Task<ApiResult<List<ECartProductModel>>> GetAllProducts()
    {
        return await _product.GetAllProducts();
    }


    [HttpPost]
    [Route("products")]
    public async Task<ApiResult> CreateProduct(ECartProductModel model)
    {
        return await _product.CreateProduct(model);
    }


    [HttpPut]
    [Route("products/{id}")]
    public async Task<ApiResult> UpdateProduct(ECartProductModel model, int id)
    {
        return await _product.UpdateProduct(model, id);
    }


    [HttpDelete]
    [Route("products/{id}")]
    public async Task<ApiResult> DeleteProduct(int id, int userId)
    {
        return await _product.DeleteProduct(id, userId);
    }
}

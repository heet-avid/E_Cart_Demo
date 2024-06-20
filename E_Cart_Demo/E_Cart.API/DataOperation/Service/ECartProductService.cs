using ECart.API.Data.Models;
using ECart.API.DataOperation.Interface;
using ECart.API.Repository.Interface;

namespace ECart.API.DataOperation.Service;
public class ECartProductService : IECartProductService
{
    private readonly IECartProductRepository _product;
    public ECartProductService(IECartProductRepository productService)
    {
        _product = productService;
    }
    public Task<ApiResult> CreateProduct(ECartProductModel model)
    {
        return _product.CreateProduct(model);
    }

    public Task<ApiResult> DeleteProduct(int id, int userId)
    {
        return _product.DeleteProduct(id, userId);
    }

    public Task<ApiResult<List<ECartProductModel>>> GetAllProducts()
    {
        return _product.GetAllProducts();
    }

    public Task<ApiResult> UpdateProduct(ECartProductModel model, int id)
    {
        return _product.UpdateProduct(model, id);
    }
}
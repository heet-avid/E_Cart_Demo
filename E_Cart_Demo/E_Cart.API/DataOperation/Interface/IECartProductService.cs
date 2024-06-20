using ECart.API.Data.Models;

namespace ECart.API.DataOperation.Interface;

public interface IECartProductService
{
    public Task<ApiResult<List<ECartProductModel>>> GetAllProducts();
    public Task<ApiResult> CreateProduct(ECartProductModel model);
    public Task<ApiResult> UpdateProduct(ECartProductModel model, int id);
    public Task<ApiResult> DeleteProduct(int id, int userId);
}

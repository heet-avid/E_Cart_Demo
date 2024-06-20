using ECart.API.Data.Models;

namespace ECart.API.DataOperation.Interface;

public interface IECartUserService
{
    public Task<ApiResult> UserSignUp(ECartUserModel model);
    public Task<ApiResult<ECartUserModel>> UserSignIn(ECartSignInModel model);
}

using ECart.API.Data.Models;

namespace ECart.API.Repository.Interface;
public interface IECartUserRepository
{
    public Task<ApiResult> UserSignUp(ECartUserModel model);
    public Task<ApiResult<ECartUserModel>> UserSignIn(ECartSignInModel model);
}

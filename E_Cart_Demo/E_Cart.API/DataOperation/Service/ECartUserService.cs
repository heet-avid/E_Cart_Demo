using ECart.API.Data.Models;
using ECart.API.DataOperation.Interface;
using ECart.API.Repository.Interface;

namespace ECart.API.DataOperation.Service;

public class ECartUserService : IECartUserService
{
    private readonly IECartUserRepository _user;

    public ECartUserService(IECartUserRepository userService)
    {
        _user = userService;
    }

    public Task<ApiResult<ECartUserModel>> UserSignIn(ECartSignInModel model)
    {
        return _user.UserSignIn(model);
    }

    public Task<ApiResult> UserSignUp(ECartUserModel model)
    {
        return _user.UserSignUp(model);
    }
}

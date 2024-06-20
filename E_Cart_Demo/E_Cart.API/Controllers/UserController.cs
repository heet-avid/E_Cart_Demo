using ECart.API.Data.Models;
using ECart.API.DataOperation.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ECart.API.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IECartUserService _user;

    public UserController(IECartUserService user)
    {
        _user = user;
    }

    [HttpPost]
    [Route("SignUp")]
    public async Task<ApiResult> UserSignUp([FromBody] ECartUserModel model)
    {
        return await _user.UserSignUp(model);
    }

    [HttpPost]
    [Route("SignIn")]
    public async Task<ApiResult<ECartUserModel>> UserSignIn([FromBody] ECartSignInModel model)
    {
        return await _user.UserSignIn(model);
    }
}

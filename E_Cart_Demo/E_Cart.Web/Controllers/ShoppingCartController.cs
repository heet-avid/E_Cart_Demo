using ECart.Web.Utility;
using Microsoft.AspNetCore.Mvc;

namespace ECart.Web.Controllers;

[Session]
public class ShoppingCartController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

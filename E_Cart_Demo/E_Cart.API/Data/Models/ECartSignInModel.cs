using System.ComponentModel.DataAnnotations;

namespace ECart.API.Data.Models;

public class ECartSignInModel
{
    [Required(ErrorMessage = "Username is required")]
    public string? Username { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; }
}

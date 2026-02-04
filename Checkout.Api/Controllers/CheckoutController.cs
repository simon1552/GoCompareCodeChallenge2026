using Checkout.Api.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Checkout.Api.Controllers;

[ApiController]
[Route("checkout")]
public class CheckoutController : ControllerBase
{
    [HttpPost]
    public Task<IActionResult> PostCheckout([FromBody] CheckoutRequest request)
        => throw new NotImplementedException();
}

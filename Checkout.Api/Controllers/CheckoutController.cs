using Checkout.Api.Domain.Models;
using Checkout.Api.Domain.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Checkout.Api.Controllers;

[ApiController]
[Route("checkout")]
public class CheckoutController(ILogger<CheckoutController> logger, ICheckoutService checkoutService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(CheckoutResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> PostCheckout([FromBody] CheckoutRequest request)
    {
        try
        {
            var total = await checkoutService.PriceAsync(request);
            return Ok(new CheckoutResponse { Total = total });
        }
        catch (Exception ex)
        {
            // Would use logger to track errors
            const string message = "Failed to get request from body";
            logger.LogError(ex, message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}

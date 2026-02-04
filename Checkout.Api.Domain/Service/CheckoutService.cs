using Checkout.Api.Domain.Models;

namespace Checkout.Api.Domain.Service;

public class CheckoutService
{

    public Task<int> PriceAsync(CheckoutRequest request)
    {
        if (request is null)
            return Task.FromResult(0);

        if (request.Sku == "A")
            return Task.FromResult(50);

        return Task.FromResult(0);
    }

}
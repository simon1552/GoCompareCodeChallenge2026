using Checkout.Api.Domain.Models;

namespace Checkout.Api.Domain.Services.Interface;

public interface ICheckoutService
{
    public ValidDiscounts ValidDiscounts { get;  }
    public ValidSku ValidSku { get; }

    Task<int> PriceAsync(CheckoutRequest request);
}
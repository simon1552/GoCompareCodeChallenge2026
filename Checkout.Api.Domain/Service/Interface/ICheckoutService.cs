using Checkout.Api.Domain.Models;
using Checkout.Api.Domain.Services;

namespace Checkout.Api.Domain.Service.Interface;

public interface ICheckoutService
{
    public ValidDiscounts ValidDiscounts { get;  }
    public ValidSku ValidSku { get; }

    Task<int> PriceAsync(CheckoutRequest request);
}
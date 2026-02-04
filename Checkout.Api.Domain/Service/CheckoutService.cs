using Checkout.Api.Domain.Models;
using Checkout.Api.Domain.Service.Interface;
using Checkout.Api.Domain.Services;

namespace Checkout.Api.Domain.Service;

public class CheckoutService: ICheckoutService
{
    public ValidDiscounts ValidDiscounts { get; }
    public ValidSku ValidSku { get; }

    public Task<int> PriceAsync(CheckoutRequest request)
    {

        return Task.FromResult(0);
    }
    
    private int GetTotal(List<Sku> skuList)
    {
        var grossTotal = skuList.Sum(sku => sku.Price);

        return grossTotal;
    }

}
using Checkout.Api.Domain.Models;

namespace Checkout.Api.Domain.Service;

public class CheckoutService
{

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
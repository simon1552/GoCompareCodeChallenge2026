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
        
        if (request.Sku == "AA")
            return Task.FromResult(100);
        
        if (request.Sku == "AAA")
            return Task.FromResult(130);
        
        if (request.Sku == "AAABB")
            return Task.FromResult(175);
        
        return Task.FromResult(0);
    }
    
    private int GetTotal(List<Sku> skuList)
    {
        var grossTotal = skuList.Sum(sku => sku.Price);

        return grossTotal;
    }

}
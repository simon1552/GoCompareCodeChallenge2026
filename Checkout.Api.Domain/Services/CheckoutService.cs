using Checkout.Api.Domain.Models;
using Checkout.Api.Domain.Services.Interface;

namespace Checkout.Api.Domain.Services;

public class CheckoutService: ICheckoutService
{
    public ValidDiscounts ValidDiscounts { get; } = new();
    public ValidSku ValidSku { get; } = new();

    public Task<int> PriceAsync(CheckoutRequest request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request), "Checkout request cannot be null.");
        
        if (request.Sku is null)
            throw new ArgumentNullException(nameof(request.Sku), "SKU string cannot be null.");
        
        var skuString = new string(request.Sku.Where(c => !char.IsWhiteSpace(c)).ToArray())
            .ToUpperInvariant();

        List<string> list = skuString.Select(c => c.ToString()).ToList();

        var skuList = MapToList(list);
        var discount = GetTotal(skuList);
        
        return Task.FromResult(discount);
    }

    private List<Sku> MapToList(List<string> skus)
    {
        var skuList = new List<Sku>();
        foreach (var sku in skus)
        {
            ValidSku.SkuList.Where(c => c.Name == sku).ToList().ForEach(c => skuList.Add(c));
        }
        return skuList;
    }
    
    private int GetTotal(List<Sku> skuList)
    {
        var grossTotal = skuList.Sum(sku => sku.Price);
        var discountTotal = ValidDiscounts.DiscountList.Sum(disc => CalculateDiscount(disc, skuList));

        return grossTotal - discountTotal;;
    }
    
    private int CalculateDiscount(Discounts discount, List<Sku> skus)
    {
        int countOfSkus = skus.Count(sku => sku.Name == discount.Item);
        return (countOfSkus / discount.Threshold) * discount.Price;
    }

}
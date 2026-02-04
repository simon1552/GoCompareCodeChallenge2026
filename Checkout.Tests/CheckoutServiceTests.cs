using Checkout.Api.Domain.Models;
using Checkout.Api.Domain.Service;

namespace Checkout.Tests;

public class CheckoutServiceTests
{
    [Fact]
    public async Task GivenPriceAsync_WhenEmptyRequest_ThenReturnsZero()
    {
        var svc = new CheckoutService();
        var request = new CheckoutRequest { Sku = "" };

        var total = await svc.PriceAsync(request);

        Assert.Equal(0, total);
    }
    
    [Fact]
    public async Task GivenPriceAsync_WhenCheckoutReceivesSingleItem_ThenReturnsPrice()
    {
        // Arrange
        var checkout = new CheckoutService();
        var request = new CheckoutRequest { Sku = "A" };

        // Act
        var result = await checkout.PriceAsync(request);

        // Assert
        Assert.Equal(50, result);
    }
    
    [Fact]
    public async Task GivenPriceAsync_WhenCheckoutReceivesMultipleItemsWithoutDiscount_ThenReturnsTotalPrice()
    {
        // Arrange
        var checkout = new CheckoutService();
        var request = new CheckoutRequest { Sku = "AA" };

        // Act
        var result = await checkout.PriceAsync(request);

        // Assert
        Assert.Equal(100, result);
    }
    
    [Fact]
    public async Task GivenPriceAsync_WhenRequestIsAAA_ThenReturns130()
    {
        // Arrange
        var service = new CheckoutService();
        var request = new CheckoutRequest { Sku = "AAA" };

        // Act
        var total = await service.PriceAsync(request);

        // Assert
        Assert.Equal(130, total);
    }
    
    [Fact]
    public async Task GivenPriceAsync_WhenRequestIsAAABB_ThenReturns175()
    {
        // Arrange
        var service = new CheckoutService();
        var request = new CheckoutRequest { Sku = "AAABB" };

        // Act
        var total = await service.PriceAsync(request);

        // Assert
        Assert.Equal(175, total);
    }

}
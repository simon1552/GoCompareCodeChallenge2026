using Checkout.Api.Domain.Models;
using Checkout.Api.Domain.Services;

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
    public async Task GivenPriceAsync_WhenCheckoutReceivesSingleItem_ThenReturns50()
    {
        // Arrange
        var checkout = new CheckoutService();
        var request = new CheckoutRequest { Sku = "A" };

        // Act
        var total = await checkout.PriceAsync(request);

        // Assert
        Assert.Equal(50, total);
    }
    
    [Fact]
    public async Task GivenPriceAsync_WhenCheckoutReceivesMultipleItemsWithoutDiscount_ThenReturns100()
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
    public async Task GivenPriceAsync_WhenRequestIsAB_ThenReturns80()
    {
        // Arrange
        var service = new CheckoutService();
        var request = new CheckoutRequest { Sku = "AB" };

        // Act
        var total = await service.PriceAsync(request);

        // Assert
        Assert.Equal(80, total);
    }
    
    [Fact]
    public async Task GivenPriceAsync_WhenRequestIsCDBA_ThenReturns115()
    {
        // Arrange
        var service = new CheckoutService();
        var request = new CheckoutRequest { Sku = "CDBA" };

        // Act
        var total = await service.PriceAsync(request);

        // Assert
        Assert.Equal(115, total);
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
    
    //Edge case
    [Fact]
    public async Task GivenPriceAsync_WhenRequestIsNull_ThenThrowsArgumentNullException()
    {
        // Arrange
        var service = new CheckoutService();
        var request = new CheckoutRequest { Sku = null! };
            
        // Act // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            await service.PriceAsync(request));
    }
    
    [Fact]
    public async Task GivenPriceAsync_WhenRequestIsLowercase_ThenHandledNormallyAndReturns80()
    {
        // Arrange
        var service = new CheckoutService();
        var request = new CheckoutRequest { Sku = "ab" };

        // Act
        var total = await service.PriceAsync(request);

        // Assert
        Assert.Equal(80, total);
    }

}
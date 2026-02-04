using Checkout.Api.Domain.Service;

namespace Checkout.Tests;

public class CheckoutServiceTests
{
    [Fact]
    public void CheckoutReceivesEmptyStringReturnsZero()
    {
        //Arrange
        var checkout = new CheckoutService();
        
        //Act
        checkout.Scan("");
        var results = checkout.GetTotal();

        //Assert
        Assert.Fail();

    }
}
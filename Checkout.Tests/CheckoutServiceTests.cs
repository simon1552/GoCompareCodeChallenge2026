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
        Assert.Equal(0, results);

    }
    
    [Theory]
    [InlineData("A", 50)]
    [InlineData("B", 30)]
    [InlineData("C", 20)]
    [InlineData("D", 15)]
    public void CheckoutReceivesSingleItemAndReturnsPrice(string item, int price)
    {
        // Arrange
        var checkout = new CheckoutService();

        // Act
        var result = checkout.Scan(item);

        // Assert
        Assert.Equal(price, result);
    }
}
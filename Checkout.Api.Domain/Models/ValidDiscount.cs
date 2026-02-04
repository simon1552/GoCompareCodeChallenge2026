namespace Checkout.Api.Domain.Models;

public class ValidDiscounts
{
    public List<Discounts> DiscountList { get; }
    
    public ValidDiscounts()
    {
        DiscountList = new List<Discounts>
        {
            new Discounts{Item = "A", Price = 20, Threshold = 3},
            new Discounts{Item = "B", Price = 15, Threshold = 2}
        };
    }
}
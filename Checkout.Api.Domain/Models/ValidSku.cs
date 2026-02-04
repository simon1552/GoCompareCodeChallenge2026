namespace Checkout.Api.Domain.Models;

public class ValidSku
{
    public List<Sku> SkuList { get; }
    public ValidSku()
    {
        SkuList = new List<Sku>
        {
            new Sku{Name = "A", Price = 50},
            new Sku{Name = "B", Price = 30},
            new Sku{Name = "C", Price = 20},
            new Sku{Name = "D", Price = 15},
        };
    }
}
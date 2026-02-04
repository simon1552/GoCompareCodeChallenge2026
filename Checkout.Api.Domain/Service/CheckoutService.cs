namespace Checkout.Api.Domain.Service;

public class CheckoutService
{

    public int Scan(String item)
    {
        if (item == null) 
        {
            return 0;
        }
        return 1;
    }
    
    public int GetTotal()
    {
        return 0; 
    }
}
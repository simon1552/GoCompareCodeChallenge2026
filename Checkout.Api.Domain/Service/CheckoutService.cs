namespace Checkout.Api.Domain.Service;

public class CheckoutService
{

    public int Scan(String item)
    {
        if (item == null) 
        {
            return 0;
        }
        switch (item)
        {
            case "A":
                return 50;
            case "B":
                return 30;
            case "C":
                return 20;
            case "D":
                return 15;
        }
        return 1;
    }
    
    public int GetTotal()
    {
        return 0; 
    }
}
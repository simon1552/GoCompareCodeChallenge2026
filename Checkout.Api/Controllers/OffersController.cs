using Microsoft.AspNetCore.Mvc;

namespace Checkout.Api.Controllers;

[ApiController]
[Route("offers")]
public class OffersController : ControllerBase
{
        
    /*
     * Currently, our system only accommodates one type of offer — multi-buy discounts.
     * However, we anticipate introducing a variety of offer types in the future, details of which are yet to be confirmed.
     * **We encourage you to design your solution with flexibility in mind, allowing for easy integration of new offer types as they become available.**
     */
    
    // I would add a create Offer endpoint and enable endpoint which we can add new offers on and disable any current offers 
    


}
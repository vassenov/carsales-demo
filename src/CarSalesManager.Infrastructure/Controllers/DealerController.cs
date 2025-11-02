using CarSalesManager.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarSalesManager.Infrastructure.Controllers;

[ApiController]
public class DealerController(IMediator mediator) : ControllerBase
{
    [HttpGet(ApiRoutes.Dealers.GetAll)]
    public async Task<IActionResult> AllDealers()
    {
        var outputResult = await mediator.Send(new AllDealersQuery());

        return Ok(outputResult);
    }
}

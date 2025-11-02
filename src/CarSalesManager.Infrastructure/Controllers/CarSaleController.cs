using CarSalesManager.Application;
using CarSalesManager.Infrastructure.DataModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarSalesManager.Infrastructure.Controllers;

[ApiController]
public class CarSaleController(IMediator mediator) : ControllerBase
{
    [HttpPost(ApiRoutes.CarSales.Create)]
    public async Task<IActionResult> CreateCarSale(CreateCarSaleModel dto)
    {
        var command = dto.ToCommand();
        var outputResult = await mediator.Send(command);

        return Ok(outputResult);
    }

    [HttpGet(ApiRoutes.CarSales.GetAll)]
    public async Task<IActionResult> AllCarSales()
    {
        var outputResult = await mediator.Send(new AllCarSalesQuery());

        return Ok(outputResult);
    }
}

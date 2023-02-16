using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PriceScrapper.Application.Request;
using YF.SharedKernel.Common;

namespace PriceScrapper.Api.Controllers;

[Route("api/[controller]/[action]")]
public class PricesController : BaseController
{
    [HttpGet]
    public async Task<IEnumerable<StockDto>> GetLatestsPrices()
    {
        var response = await Mediator.Send(new GetAllStocksRequest());

        return response;
    }

    [HttpGet]
    public async Task<DateTime?> GetLastFetchDate()
    {
        var response = await Mediator.Send(new GetDateOfLastFetchRequest());

        return response;
    }
}

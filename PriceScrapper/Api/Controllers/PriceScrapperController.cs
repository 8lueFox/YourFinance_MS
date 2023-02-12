using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PriceScrapper.Application.Common.Interfaces;
using YF.SharedKernel.Common;

namespace PriceScrapper.Api.Controllers;

public class PriceScrapperController : BaseController
{
    [HttpGet]
    public async Task<ActionResult> StartFetchingStocks()
    {
        var response = await Mediator.Send(new FetchStocksRequest());
        if(response)
            return Ok(response);
        else
            return BadRequest(response);
    }
}

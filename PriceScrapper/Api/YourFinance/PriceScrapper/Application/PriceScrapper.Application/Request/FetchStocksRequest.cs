﻿using MediatR;
using Microsoft.Extensions.Logging;
using PriceScrapper.Application.Common.Interfaces;

public record FetchStocksRequest () : IRequest<bool>;

public class FetchStocksRequestHandler : IRequestHandler<FetchStocksRequest, bool>
{
    private readonly IScrapper _scrapper;
    //private readonly ILogger _logger;

    public FetchStocksRequestHandler(IScrapper scrapper)//, ILogger logger)
    {
        _scrapper = scrapper;
        //_logger = logger;
    }

    public Task<bool> Handle(FetchStocksRequest request, CancellationToken cancellationToken)
    {
        //_logger.LogInformation("start fetching stocks");
        try
        {
            _scrapper.FetchStocks(cancellationToken);
        }
        catch (Exception ex)
        {
            //_logger.LogInformation($"error during stocks was fetching {ex.Message}");
            return Task.FromResult(false);
        }
        //_logger.LogInformation("ended fetch stocks");
        return Task.FromResult(true);
    }
}
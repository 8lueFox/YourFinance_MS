namespace PriceScrapper.Application.Common.Interfaces;

public interface IScrapper : ITransientService
{
    Task<bool> FetchStocks(CancellationToken ct);
}

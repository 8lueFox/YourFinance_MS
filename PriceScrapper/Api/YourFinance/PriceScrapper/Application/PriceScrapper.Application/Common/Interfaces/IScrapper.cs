namespace PriceScrapper.Application.Common.Interfaces;

public interface IScrapper : ITransientService
{
    void FetchStocks(CancellationToken ct);
}

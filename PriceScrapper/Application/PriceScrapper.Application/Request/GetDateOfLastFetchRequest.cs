using Ardalis.Specification;
using MediatR;
using PriceScrapper.Domain.Entities;
using YF.SharedKernel.Common.Persistence;

namespace PriceScrapper.Application.Request;

public record GetDateOfLastFetchRequest() : IRequest<DateTime?>;

public class LastFetchDateSpec : Specification<Stock>
{
    public LastFetchDateSpec() =>
        Query.OrderByDescending(x => x.FetchData);
}

public class GetDateOfLastFetchRequestHandler : IRequestHandler<GetDateOfLastFetchRequest, DateTime?>
{
    private readonly IRepository<Stock> _repo;

    public GetDateOfLastFetchRequestHandler(IRepository<Stock> repo)
    {
        _repo = repo;
    }

    public async Task<DateTime?> Handle(GetDateOfLastFetchRequest request, CancellationToken cancellationToken)
    {
        var stock = await _repo.FirstOrDefaultAsync(new LastFetchDateSpec(), cancellationToken);

        return stock?.FetchData;
    }
}

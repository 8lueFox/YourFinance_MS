using Ardalis.Specification;
using AutoMapper;
using MediatR;
using PriceScrapper.Domain.Entities;
using YF.SharedKernel.Common;
using YF.SharedKernel.Common.Persistence;

namespace PriceScrapper.Application.Request;

public record GetAllStocksRequest() : IRequest<IEnumerable<StockDto>>;

public class GetAllStocksRequestHandler : IRequestHandler<GetAllStocksRequest, IEnumerable<StockDto>>
{
    private readonly IRepository<Stock> _repo;
    private readonly IMapper _mapper;

    public GetAllStocksRequestHandler(IRepository<Stock> repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<StockDto>> Handle(GetAllStocksRequest request, CancellationToken cancellationToken)
    {
        return _mapper.Map<IEnumerable<StockDto>>(await _repo.ListAsync());
    }
}

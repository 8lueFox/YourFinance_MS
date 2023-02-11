using PriceScrapper.Application.Common.Interfaces;
using PriceScrapper.Domain.Entities;
using YF.SharedKernel.Common.Persistence;
using Mapster;
using AutoMapper;

namespace PriceScrapper.Infrastructure.Scrapper;

public class ScrapperSaver : IScrapperSaver
{
    private readonly IRepository<Stock> _repo;
    private readonly IMapper _mapper;

    public ScrapperSaver(
        IRepository<Stock> repo,
        IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async void Save(Root root)
    {
        var stocks = _mapper.Map<IEnumerable<Stock>>(root.data.rows);

        await _repo.AddRangeAsync(stocks);
        await _repo.SaveChangesAsync();
    }
}

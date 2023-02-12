namespace PriceScrapper.Application.Common.Interfaces;

public interface IScrapperSaver : ITransientService
{
    Task<bool> SaveAsync(Root root);
}

namespace PriceScrapper.Application.Common.Interfaces;

public interface IScrapperSaver : ITransientService
{
    void Save(Root root);
}

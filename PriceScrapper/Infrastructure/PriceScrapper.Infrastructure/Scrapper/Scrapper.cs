using PriceScrapper.Application.Common.Interfaces;
using PriceScrapper.Domain.Entities;
using RestSharp;
using System.Text.Json;
using YF.SharedKernel.Common.Persistence;

namespace PriceScrapper.Infrastructure.Scrapper;

public class Scrapper : IScrapper
{
    private readonly IScrapperSaver _saver;

    public Scrapper( 
        IScrapperSaver saver)
    {
        _saver = saver;
    }

    //https://api.nasdaq.com/api/screener/stocks?tableonly=true&limit=25&offset=0&download=true
    public async Task<bool> FetchStocks(CancellationToken ct)
    {
        try
        {
            var client = new RestClient("https://api.nasdaq.com/api");
            var request = new RestRequest("screener/stocks?tableonly=true&limit=25&offset=0&download=true");
            
            client.AddDefaultHeader("User-Agent", "PostmanRuntime/7.29.2");
            client.AddDefaultHeader("Accept", "*/*");

            request.Timeout = 15 * 1000;
            var response = await client.GetAsync(request, ct);

            Root data;
            if(response.IsSuccessStatusCode)
            {
                data = JsonSerializer.Deserialize<Root>(response.Content!)!;
                return await _saver.SaveAsync(data);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while making the request: " + ex.Message);
        }
        return true;
    }
}

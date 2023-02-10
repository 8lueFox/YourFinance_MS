using PriceScrapper.Application.Common.Interfaces;
using PriceScrapper.Application.Request;
using PriceScrapper.Domain.Entities;
using RestSharp;
using Sylvan.Data.Csv;
using System.Net;
using System.Net.Http.Headers;
using YF.SharedKernel.Common.Persistence;
using System.Net.Http.Formatting;
using CliWrap;
using System.Reflection;
using Microsoft.Scripting.Hosting;
using IronPython.Hosting;

namespace PriceScrapper.Infrastructure.Scrapper;

public class Scrapper : IScrapper
{
    //private readonly IRepository<Stock> _repo;

    //public Scrapper(IRepository<Stock> repo)
    //{
    //    _repo = repo;
    //}

    public async void FetchStocks(CancellationToken ct)
    {
        string url = "https://api.nasdaq.com/api/screener/stocks?tableonly=true&limit=25&offset=0&download=true";

        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.KeepAlive = false;
            request.UserAgent = "PostmanRuntime/7.29.2";
            request.Accept = "*/*";
            request.Timeout = 30 * 1000;  // 60 second timeout

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string responseText = reader.ReadToEnd();

            Console.WriteLine(responseText);
        }
        catch (WebException ex)
        {
            Console.WriteLine("An error occurred while making the request: " + ex.Message);
        }
    }

    //public void FetchStocksFromCsv()
    //{
    //    //fetched from https://www.nasdaq.com/market-activity/stocks/screener
    //    using (var csvReader = CsvDataReader.Create(@"C:\Users\kjedrzejewski\Downloads\nasdaq_screener_1675470926609.csv"))
    //    {
    //        var data = new List<StockCreateDto>();

    //        while (csvReader.Read())
    //        {
    //            if (csvReader.RowFieldCount < 10)
    //                continue;
    //            StockCreateDto item = new()
    //            {
    //                Symbol = csvReader.GetString(0),
    //                Name = csvReader.GetString(1),
    //                LastSale = decimal.Parse(csvReader.GetString(2).Trim('$').Replace('.', ',')),
    //                NetChange = decimal.Parse(csvReader.GetString(3).Replace('.', ',')),
    //                Change = decimal.Parse(csvReader.GetString(4).Trim('%').Replace('.', ','))
    //            };
    //            data.Add(item);
    //        }
    //    }
    //}
}

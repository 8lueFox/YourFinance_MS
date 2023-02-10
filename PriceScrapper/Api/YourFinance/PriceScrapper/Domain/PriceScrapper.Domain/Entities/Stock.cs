using System.ComponentModel.DataAnnotations;
using YF.SharedKernel.Common;

namespace PriceScrapper.Domain.Entities;

public class Stock : BaseEntity
{
    [Required]
    public string Symbol { get; set; } = string.Empty;

    [Required]
    public string Name { get; set; } = string.Empty;

    public decimal? LastSale { get; set; }

    public decimal? NetChange { get; set; }

    public decimal? Change { get; set; }

    public decimal? PCTChange { get; set; }

    public decimal? Volume { get; set; }

    public decimal? MarketCap { get; set; }

    public string? Country { get; set; }

    public string? Ipoyear { get; set; }

    public string? Industry { get; set; }

    public string? Sector { get; set; }

    public string? Url { get; set; }
}

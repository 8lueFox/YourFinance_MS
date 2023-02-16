using System.ComponentModel.DataAnnotations;

namespace PriceScrapper.Application.Request;

public class StockDto
{
    [Required]
    public string Symbol { get; set; } = string.Empty;

    [Required]
    public string Name { get; set; } = string.Empty;

    public decimal LastSale { get; set; }

    public decimal NetChange { get; set; }

    public decimal PctChange { get; set; }
}

using Microsoft.EntityFrameworkCore;
using PriceScrapper.Application;
using PriceScrapper.Application.Common.Interfaces;
using PriceScrapper.Infrastructure;
using PriceScrapper.Infrastructure.Persistence;
using PriceScrapper.Infrastructure.Scrapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
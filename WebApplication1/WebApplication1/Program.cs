using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Configuration;
using WebApplication1.Data;
using WebApplication1.Dto;
using WebApplication1.Service;
using WebApplication1.Service.File;
using WebApplication1.Service.ServiceImpl;
using WebApplication1.Service.Stretagies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IEquipmentService, EquipmentService>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDb>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IFileService, LocalFileService>();
builder.Services.AddScoped<IStretagySelector, StretagySelector>();
builder.Services.AddScoped<IPricingStretagy,DailyPricingStrategy>();
builder.Services.AddScoped<IPricingStretagy,WeekendPricingStretagy>();
builder.Services.AddScoped<IRentalService, RentalService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDb>();
    db.Database.EnsureCreated();
}



app.MapPost("/create-items", async ([FromForm] EquipmentDto equipment,IEquipmentService equipmentService) =>
{
    await equipmentService.CreateEquipmentAsync(equipment);
    return Results.Ok();

}).DisableAntiforgery();



app.MapPost("/calculate-price-date", (PriceDecidesDto priceDecides, IRentalService rentalService) =>
{
    return rentalService.PriceCalculateOnStretagy(priceDecides);

});
app.Run();

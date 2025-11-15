using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Configuration;
using WebApplication1.Data;
using WebApplication1.Dto;
using WebApplication1.Service;
using WebApplication1.Service.File;
using WebApplication1.Service.Observers;
using WebApplication1.Service.ServiceImpl;
using WebApplication1.Service.Stretagies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

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
builder.Services.AddSingleton<IRentalSubject, RentalSubject>();
builder.Services.AddSingleton<IRentalObserver, RenterObserver>();



var app = builder.Build();

app.UseCors("AllowAll");

app.MapControllers();



app.Services.GetRequiredService<IRentalObserver>();


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

app.MapPost("/create-rental", async (RentalDto rental, IRentalService rentalService) =>
{
    await rentalService.CreateRentalAsync(rental);
    return Results.Ok();

});

app.MapGet("/find-rentals-by-userId/{userId:int}",async (int userId,IRentalService rentalService) =>
{
    return await rentalService.GetRentalAsync(userId);
});

app.MapPatch("/approve-rental/{rentalId:int}", async (int rentalId,IRentalService rentalService) =>
{
    return await rentalService.ApproveRentalAsync(rentalId);

});

app.MapPatch("/start-rental/{rentalId:int}",async (int rentalId,IRentalService rentalService)=>
{
    return await rentalService.StartRentalAsync(rentalId);
});

app.MapPatch("/complete-rental/{rentalId:int}", async (int rentalId, IRentalService rentalService) =>
{
    return await rentalService.CompleteRentalAsync(rentalId);

});

app.MapPatch("/cancel-rental/{rentalId:int}", async (int rentalId, IRentalService rentalService) =>
{
    return await rentalService.CancelRentalAsync(rentalId);

});
app.MapGet("/notify-rental/{rentalId:int}",  (int rentalId, IRentalService rentalService) =>
{
    return rentalService.NotifyRental(rentalId);

});

app.MapGet("/get-all-rentals/",  (IEquipmentService equipmentService) =>
{
    return equipmentService.GetAllEquipments();

});


app.MapGet("/get-all-rentals-by-category/{category}",  (string category,IEquipmentService equipmentService) =>
{
    return equipmentService.GetAllEquipmentsByCategory(category);

});
app.MapGet("/get-all-rentals-by-letters/{letter}",  (string letter,IEquipmentService equipmentService) =>
{
    return equipmentService.GetAllEquipmentsByLetter(letter);

});

app.MapGet("/get-all-rentals-by-title/{title}",  (string title,IEquipmentService equipmentService) =>
{
    return equipmentService.GetAllEquipmentsByTitle(title);

});


app.Run();

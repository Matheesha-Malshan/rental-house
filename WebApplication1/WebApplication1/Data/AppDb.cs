using Microsoft.EntityFrameworkCore;
using WebApplication1.model;


namespace WebApplication1.Data;

public class AppDb:DbContext
{
    public AppDb(DbContextOptions<AppDb> options) : base(options)
    {
    }
    public DbSet<Rental> Rentals => Set<Rental>();
    public DbSet<Equipment> Equipments => Set<Equipment>();

}
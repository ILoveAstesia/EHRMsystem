using Microsoft.EntityFrameworkCore;
using EHRMsystem.Model;
namespace EHRMsystem.Data;

public class EHRMContext : DbContext
{
    public EHRMContext(DbContextOptions options) : base(options)
    {
        if (Persons==null)
        {
        Console.WriteLine("EHRMContext when constroctor finishing Persons is null");
        Environment.Exit(0);
        }
        if (Departments==null)
        {
        Console.WriteLine("EHRMContext when constroctor finishing Departments is null");
        Environment.Exit(0);
        }

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        // modelBuilder.Entity<Person>()
        //     .HasMany(e => e.Departments)
        //     .WithMany(e => e.Persons);

    }

    public DbSet<Person> Persons { get; set; }
    public DbSet<Department> Departments { get; set; }
}
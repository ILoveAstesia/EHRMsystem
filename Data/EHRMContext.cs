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

    public DbSet<Person> Persons { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<DepartmentPerson> DepartmentPersons { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>().HasData(
            new {
                Id=0001,
                Name="Food", 
            },
                        new {
                Id=0002,
                Name="Drink", 
            }
        );
        modelBuilder.Entity<Person>().HasData(          
            new List<Person> {
                new(){                
                Id=0003,
                Name="Basic Cheese Pizza",
                },
                new(){    
                Id=0004,
                Name="Cola",
                }
            });
        // modelBuilder.Entity<PerDep>().HasNoKey();        
        
        modelBuilder.Entity<DepartmentPerson>().HasData(          
        new List<DepartmentPerson> {
            new(){   
                Id=1,             
            PersonId=0001,
            DepartmentId=3,
            },
            new(){    
                Id=2,
            PersonId=0002,
            DepartmentId=0004,
            }
        });
            
        

        // modelBuilder.Entity<Person>()
        //      .HasMany(e => e.Departments)
        //      .WithMany(e => e.Persons);
        
        //  modelBuilder.Entity<Person>()
        //         .HasMany(p => p.Departments)
        //         .WithMany(d => d.Persons)
        //         .UsingEntity<Dictionary<string, object>>(
        //             "PersonDepartment",
        //             r => r.HasOne<Department>().WithMany().HasForeignKey("DepartmentId"),
        //             l => l.HasOne<Person>().WithMany().HasForeignKey("PersonId"),
        //             je =>
        //             {
        //                 je.HasKey("PersonId", "DepartmentId");
        //                 je.HasData(
        //                     new { PersonId = 1, DepartmentId = 3 },
        //                     new { PersonId = 2, DepartmentId = 4 }
        //                     // new { PersonId = 2, DepartmentId = 13 },
        //                     // new { PersonId = 3, DepartmentId = 14 },
        //                     // new { PersonId = 4, DepartmentId = 15 },
        //                     // new { PersonId = 4, DepartmentId = 15 }
        //                     );
        //             });
    }

}
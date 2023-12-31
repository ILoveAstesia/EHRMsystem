using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using EHRMsystem.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();


//conect to my sql
builder.Services.AddDbContext<EHRMContext>(opt =>
{
    var cs=builder.Configuration.GetConnectionString("MySql");
    if(cs==null){
        Console.WriteLine("conectionString is null");
        Environment.Exit(0);
    }
    opt.UseMySQL(cs);
});

var app = builder.Build();

//add seeding service
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<EHRMContext>();
    if (db.Database.EnsureCreated())
    {
        SeedData.Initialize(db);
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;


var builder = WebApplication.CreateBuilder(args);

//DbContextConfiguration
builder.Services.AddDbContext<AppDbContex>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

//service configuration
builder.Services.AddScoped<IActorsService, ActorsService>();
builder.Services.AddScoped<IProducerService, ProducersService>();
builder.Services.AddScoped<ICinemasService, CinemasService>();

// Add services to the container.
builder.Services.AddControllersWithViews();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
AppDbInitializer.Seed(app);
app.Run();


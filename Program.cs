using AppGestionFranca.Models;
using AppGestionFranca.Repositories;
using AppGestionFranca.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DBContext")));
builder.Services.AddControllersWithViews();

// Add AutoMapper Injection
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Repository
builder.Services.AddScoped<ITechnicianRepository, TechnicianRepository>();
builder.Services.AddScoped<ISubsidiaryRepository, SubsidiaryRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();

// Implements The Singleton Patern
builder.Services.AddRazorPages();

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

app.Run();

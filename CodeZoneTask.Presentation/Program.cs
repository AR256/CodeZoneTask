using CodeZoneTask.Application.Services;
using CodeZoneTask.Core.Interfaces;
using CodeZoneTask.Infrastructure.Data.Context;
using CodeZoneTask.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CodeZoneTask.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<StoreContext>(a =>
            {
                a.UseSqlServer(builder.Configuration.GetConnectionString("con1"),
                    b => b.MigrationsAssembly("CodeZoneTask.Infrastructure"));
            });
            builder.Services.AddScoped<IStockService, StockService>();
            builder.Services.AddScoped<IStoreRepository, StoreRepository>();
            builder.Services.AddScoped<IItemRepository, ItemRepository>();
            builder.Services.AddScoped<IStoreItemRepository, StoreItemRepository>();

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
        }
    }
}

using Microsoft.EntityFrameworkCore;
using MVCVendasWeb.Data;
using MVCVendasWeb.Models;
using MVCVendasWeb.Services;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace MVCVendasWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<MVCVendasWebContext>(options =>
                options.UseMySql(builder.Configuration.GetConnectionString("MVCVendasWebContext"), 
                ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MVCVendasWebContext"))
            ));

            builder.Services.AddScoped<SeedingService>();
            builder.Services.AddScoped<SellerService>();
            builder.Services.AddScoped<DepartmentService>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                using (var scope = app.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;

                    try
                    {
                        var seedingService = services.GetRequiredService<SeedingService>();
                        seedingService.Seed();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao realizar o seeding: {ex.Message}");
                    }
                }
            }

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            var culture = new CultureInfo("pt-BR");
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(culture),
                SupportedCultures = [culture],
                SupportedUICultures = [culture]
            };

            app.UseRequestLocalization(localizationOptions);

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

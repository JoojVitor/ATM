using ATM.Controllers;
using ATM.Models;
using ATM.Service;
using Microsoft.EntityFrameworkCore;

namespace ATM
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Registro dos DbContexts
            builder.Services.AddDbContext<SaqueDbContext>(options =>
                options.UseInMemoryDatabase("SaqueDb"));
            builder.Services.AddDbContext<CartaoDbContext>(options =>
                options.UseInMemoryDatabase("CartaoDb"));
            builder.Services.AddDbContext<ContaDbContext>(options =>
                options.UseInMemoryDatabase("ContaDb"));

            // Registro dos serviços
            builder.Services.AddScoped<SaqueService>();
            builder.Services.AddScoped<CartaoService>();
            builder.Services.AddScoped<ContaService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
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

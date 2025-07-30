using RaporFront.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace RaporFront
{
    public class Program
    {
        private static WebApplicationBuilder? builder;
        public static void Main(string[] args)
        {
            builder = WebApplication.CreateBuilder(args);

            // Veritabaný baðlantýsý
            builder.Services.AddDbContext<UygulamaDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // MVC Controller + View servisi ekleniyor
            builder.Services.AddControllersWithViews();

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
            {
                      options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            });


            var app = builder.Build();

            // Hata yönetimi
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // Default route: Login/Login
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Login}/{id?}");

            app.Run();
        }
    }
}

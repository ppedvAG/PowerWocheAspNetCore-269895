using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPages_with_EFCore_Relationships_LazyLoading.Data;
namespace RazorPages_with_EFCore_Relationships_LazyLoading
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<GeoDbContext>(options =>
            {
                options.UseLazyLoadingProxies();
                //options.UseLazyLoadingProxies(options =>
                //{
                //    ////options.IgnoreNonVirtualNavigations ;
                //});
                options.UseSqlServer(builder.Configuration.GetConnectionString("GeoDbContext") ?? throw new InvalidOperationException("Connection string 'GeoDbContext' not found."));

            });
                
            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapRazorPages()
               .WithStaticAssets();

            app.Run();
        }
    }
}

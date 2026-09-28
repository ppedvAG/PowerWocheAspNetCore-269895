using ConfigurationSamples.Configurations;
using ConfigurationSamples.Services;

namespace ConfigurationSamples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            //Konfigurationen werden in CoffeeShopOptions gespeichert. Mit dem IOC Container können wir via IOption-Pattern darauf zugreifen.
            builder.Services.Configure<CoffeeShopOptions>(builder.Configuration.GetSection(CoffeeShopOptions.SectionName));

            builder.Services.AddSingleton<CoffeeShopMonitorState>();
            builder.Services.AddHostedService<CoffeeShopOptionsMonitorService>();
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

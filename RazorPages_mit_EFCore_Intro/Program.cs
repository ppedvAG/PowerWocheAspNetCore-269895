using Microsoft.EntityFrameworkCore;
using RazorPages_mit_EFCore_Intro.Data;

namespace RazorPages_mit_EFCore_Intro
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();


            //AddDBcontext wird als IOC (Scoped) hinzugefügt
            builder.Services.AddDbContext<MovieDbContext>(options =>
            {
                options.UseInMemoryDatabase("MovieDB");
            });

            var app = builder.Build();

            //Nach dem Build-Befehl können wir Testdaten bereitstellen
            using (IServiceScope scope = app.Services.CreateScope())
            {
                MovieDbContext ctx = scope.ServiceProvider.GetRequiredService<MovieDbContext>();
                DataSeeder.SeedMovies(ctx);
            }
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

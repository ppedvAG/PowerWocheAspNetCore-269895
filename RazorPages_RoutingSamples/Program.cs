namespace RazorPages_RoutingSamples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages(options =>
            {
                //Variante A:
                //https://localhost:7224/Blog/2025/23/12/test
                options.Conventions.AddPageRoute("/Sample/FriendlyRouteSample/Sample", "Blog/{year}/{month}/{day}/{title}");

                //Variabte B: https://localhost:7224/Blog?year=2025&month=8&day=23&title=test
                options.Conventions.AddPageRoute("/Sample/FriendlyRouteSample/Sample", "Blog");
            });

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

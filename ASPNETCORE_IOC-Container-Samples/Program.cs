using ASPNETCORE_IOC_Container_Samples.Services;

namespace ASPNETCORE_IOC_Container_Samples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            //Einstiegsbeispiel für Index.html :-) 
            builder.Services.AddSingleton<IGuidService, GuidService>();


            //Lifecylce-Beispiel für IOCLifeCycleSample.cshtml
            builder.Services.AddKeyedSingleton<IGuidService, GuidService>("Singleton");
            builder.Services.AddKeyedScoped<IGuidService, GuidService>("Scoped");
            builder.Services.AddKeyedTransient<IGuidService, GuidService>("Transient");


            //Service mit Parameter registrieren. 
            builder.Services.AddSingleton<IGreeterService>( sp =>
            {
                return new GreeterService("Teilnehmer");
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

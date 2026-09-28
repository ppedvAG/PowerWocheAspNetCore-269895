namespace FirstRazorPageApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Konfigurationen u.a appsetting.json,Enviroment Variablen, Commandline args, User Secrets (sind ab erster Codezeile geladen)
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //Add Razor Pages ist unser Framework für Razor Pages. Es registriert die benötigten Services für Razor Pages in der DI-Container.
            builder.Services.AddRazorPages();

            //Movel-View-Controller (MVC) ist ein Framework für die Entwicklung von Webanwendungen. Es registriert die benötigten Services für MVC in der DI-Container.
            //builder.Services.AddControllers(); //View und Controller - Verzeichnis

            //Kombination aus AddControllers und AddRazorPages. Es registriert die benötigten Services für MVC und Razor Pages in der DI-Container.
            //builder.Services.AddMvc();



            //Initialisierungprozess des IOC Container ist hiermit fertig
            WebApplication app = builder.Build(); //ServiceProvider wird hier erstellt. 


            //Bei Testdaten kann man mithilfe des IServiceProvider die Fake-Datenbank oder Mockdaten initialisieren. 
            //IServiceProvider provider = app.Services.CreateAsyncScope().ServiceProvider;
            //GetRequiredService + GetService kann man hier verwenden. 

            // Configure the HTTP request pipeline.

            //Wenn wir Live sind, dann verwenden wird eine Error-Page mit einer komfortablen Error-Message. 
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            //Jeder Server-Instanz (Development, Staging, Production) haben hier die gemeinsame Einstellung.
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapRazorPages()
               .WithStaticAssets();


            //Web-Awnedung ist hiermit verfügbar 
            app.Run();
        }
    }
}

using Microsoft.Extensions.DependencyInjection;

namespace IOCContainerSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Beim initialisieren des IOC Container verwenden wir die IServiceCollection und registrieren die Abhängigkeiten

            IServiceCollection services = new ServiceCollection();

            //registrieren den Logger-Service als Singleton in den Container. 
            services.AddSingleton<ILogger, ConsoleLogger>();

            //Ab hier ist die Initalisierungphase abgeschlossen und wir können den ServiceProvider erstellen, der uns die Abhängigkeiten auflöst.



            //Beispiel 2 (VOR .NET 8): Selbes Interface mit zwei Implementierungen, die wir als Singleton und Transient registrieren
            services.AddSingleton<ISingletonLogger, Logger2>();
            services.AddTransient<ITransientLogger, Logger2>(); //Lifecycle werden hier überschrieben (Letzte Gewinnt)


            //Beispiel 3 (AB .NET 8): Selbes Interface mit zwei Implementierungen, die wir als Singleton und Transient registrieren
            services.AddKeyedSingleton<ILogger, Logger2>("singletonLogger"); //Der Key wird gesetzt, damit wir später expliziet abrufen können
            services.AddKeyedTransient<ILogger, Logger2>("transientLogger");

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            


            //Zugriff auf den Logger-Service über den ServiceProvider
            ILogger? logger = serviceProvider.GetService<ILogger>();
            if (logger != null)
            {
                logger.Log("Hello, World!");
            }

            ILogger logger2 = serviceProvider.GetRequiredService<ILogger>();

            //Unterschied zwischen GetService und GetRequiredService:
            //GetService gibt null zurück, wenn der Dienst nicht registriert ist, während GetRequiredService eine Exception auslöst, wenn der Dienst nicht gefunden wird.



            //Beispiel 3: Zugriff auf die Implementierungen über den Key

            var service1 = serviceProvider.GetKeyedService<ILogger>("transientLogger");


        }
    }

    public interface ILogger
    {
        void Log(string message);
    }

    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            //Schreibe die Nachricht in eine Datei
        }
    }


    //Bis .NET 6 hatte Microsoft diesen Vorschlag eingebracht, wobei es zwei Varianten gibt: 
    public interface ISingletonLogger : ILogger
    {
        //Wäre Erweiterbar
    }

    public interface ITransientLogger : ILogger
    {
        //Wäre Erweiterbar
    }


    public class Logger2 : ISingletonLogger, ITransientLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }


}

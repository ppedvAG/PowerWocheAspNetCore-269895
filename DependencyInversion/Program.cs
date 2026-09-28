namespace DependencyInversion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Test - Objekt
            IEngine mockEngine = new MockEngine();

            //Zum Testen:
            ICar car = new Car(mockEngine);


            //Für Produktion
            car = new Car (new Engine() { PS = 150 });
        }
    }

    #region BadSample

    //Programmierer A: 3 Tage arbeit und beginnt an Tag 1 bis Tag 3
    public class BadEngine
    {
        public int PS { get; set; }
    }


    //Programmierer B: 3 Tage arbeit und beginnt an Tag 2 bis Tag 4/5
    public class BadCar
    {
        //Feste Kopplung 
        public BadEngine Engine { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        public int Year { get; set; }

        public void Drive()
        {
            //Fahre das Auto
        }
    }

    //Programmierer C: 3 Tage arbeit und beginnt an Tag 4 bis Tag 6/7
    public class BadCarService
    {

        //Feste Kopplung 
        public void Repair(BadCar car)
        {
            //repariere Auto
        }

        public void Testfahrt(BadCar car)
        {
            //Fahre das Auto zur Testfahrt
        }
    }
    #endregion


    #region GoodSample


    //Contract First 
    public interface IEngine
    {
        public int PS { get; set; }
    }

    public interface ICar
    {
        public IEngine Engine { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public void Drive();
    }

    public interface ICarService
    {
        public void Repair(ICar car);
        public void Testfahrt(ICar car);
    }


    //Programmierer A: 3 Tage arbeit und beginnt an Tag 1 bis Tag 3
    public class Engine : IEngine
    {
        public int PS { get; set; }
    }

    public class MockEngine : IEngine
    {
        public int PS { get; set; } = 120;
    }


    //Programmierer B: 3 Tage arbeit und beginnt an Tag 1 bis Tag 3
    public class Car : ICar
    {

        public Car(IEngine engine)
        {
            Engine = engine;
        }

        public IEngine Engine { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public void Drive()
        {
            //Fahre das Auto
        }
    }

    //Programmierer C: 3 Tage arbeit und beginnt an Tag 1 bis Tag 3
    public class CarService : ICarService
    {
        public void Repair(ICar car)
        {
            //repariere Auto
        }
        public void Testfahrt(ICar car)
        {
            //Fahre das Auto zur Testfahrt
        }
    }

    #endregion
}

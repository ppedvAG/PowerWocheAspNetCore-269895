namespace InterfacesSegerationPrincipe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    public interface IBadVehicle
    {
        public void Drive();
        public void Swim();
        public void Fly(); 
    }

    public class BadVehicle : IBadVehicle
    {
        public void Drive()
        {
            //Fahre das Vehicle
        }
        public void Swim()
        {
            //Lasse das Vehicle schwimmen
        }
        public void Fly()
        {
            //Lasse das Vehicle fliegen
        }
    }


    public class BadAmphibischesVehicle : IBadVehicle
    {
        public void Drive()
        {
            //Fahre das Vehicle
        }
        public void Swim()
        {
            //Lasse das Vehicle schwimmen
        }
        public void Fly()
        {
            throw new NotImplementedException();
        }
    }


    public interface IDriveable
    {
        public void Drive();
    }

    public interface ISwimmable
    {
        public void Swim();
    }

    public interface IFlyable
    {
        public void Fly();
    }

    public class AmphibischesVehicle : IDriveable, ISwimmable
    {
        public void Drive()
        {
            //Amphibisches Fahrzeug kann fahren
        }

        public void Swim()
        {
            //Amphibisches Fahrzeug kann schwimmen
        }
    }
}

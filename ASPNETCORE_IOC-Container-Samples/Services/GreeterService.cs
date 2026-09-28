namespace ASPNETCORE_IOC_Container_Samples.Services
{
    public class GreeterService : IGreeterService
    {

        private string _name = "World";

        public GreeterService(string name)
        {
            _name = name;
        }

        public string GetGreeting()
        {
            return $"Hello, {_name}!";
        }
    }
}

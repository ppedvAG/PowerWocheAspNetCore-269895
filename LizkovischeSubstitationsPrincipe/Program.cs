namespace LizkovischeSubstitationsPrincipe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    #region Bad Example
    public class BadErdbeere
    {
        public string Color { get; set; } = "Rot";

        public string GetColor()
        {
            return Color;
        }
    }

    public class BadKirsche : BadErdbeere
    {
        public string GetColor()
        {
            return base.GetColor();
        }
    }
    #endregion


    public abstract class Fruits
    {
        public abstract string GetColor();
    }

    public class Erdbeere : Fruits
    {
        public override string GetColor()
        {
            return "Rot";
        }
    }

    public class Kirsche : Fruits
    {
        public override string GetColor()
        {
            return "Rot";
        }
    }

}

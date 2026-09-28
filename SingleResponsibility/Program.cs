namespace SingleResponsibility
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }


    //Diese Klasse hat zuviele Aufgaben und verstößt gegen das Single Responsibility Principle

    public class BadEmployee
    {
        //properties werden beim Kompilieren automatisch mit einem privaten Feld hinterlegt
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public decimal Salary { get; set; }

        //DAL
        public void InsertEmployeeToDB()
        {
            //Speicher den Datensatz in die Datenbank
        }


        //Service Layer
        public void GenerateEmployeeReport()
        {
            //Generiere einen Bericht über den Mitarbeiter
        }


        //UI Layer (Presentation Layer)
        public void EmployeView()
        {
            //Zeige die Daten des Mitarbeiters in der Konsole an
        }
    }


    #region Verbesserte Version mit SRP
    public class Employee
    {
        //properties werden beim Kompilieren automatisch mit einem privaten Feld hinterlegt
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public decimal Salary { get; set; }
    }

    //Repository Layer (DAL)
    public class EmployeeRepository
    {
        public void InsertEmployeeToDB(Employee employee)
        {
            //Speicher den Datensatz in die Datenbank
        }
    }

    //Service Layer
    public class EmployeeService
    {
        public void GenerateEmployeeReport(Employee employee)
        {
            //Generiere einen Bericht über den Mitarbeiter
        }
    }
    
    //Presentation Layer (UI Layer)
    public class EmployeeView
    {
        public void ShowEmployee(Employee employee)
        {
            //Zeige die Daten des Mitarbeiters in der Konsole an
        }
    }

    #endregion
}

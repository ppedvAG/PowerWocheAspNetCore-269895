namespace OpenClosePrincipe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
    }


    public class BadReportGeneratorService
    {
        public void GenerateEmployeeReport(Employee employee, string reportType)
        {
            ReportGeneratorService service = null; 
            if (reportType == "PDF")
            {
                //Generiere einen PDF Bericht über den Mitarbeiter
                service = new PdfReportGeneratorService();
            }
            else if (reportType == "CrystalReports")
            {
                //Generiere einen Crystal Reports Bericht über den Mitarbeiter
                service = new CrystalReportGeneratorService();
            }
            else if (reportType == "FastReport")
            {
                //Generiere einen FastReport Bericht über den Mitarbeiter
                service = new FastReportGeneratorService();
            }

            service?.GenerateEmployeeReport(employee);
        }
    }


    //Verbesserte Version mit OCP

    public abstract class ReportGeneratorService
    {
        public abstract void GenerateEmployeeReport(Employee employee);
    }

    //PDF Report Generator
    public class PdfReportGeneratorService : ReportGeneratorService
    {
        public override void GenerateEmployeeReport(Employee employee)
        {
            //Generiere einen PDF Bericht über den Mitarbeiter
        }
    }

   public class CrystalReportGeneratorService : ReportGeneratorService
    {
        public override void GenerateEmployeeReport(Employee employee)
        {
            //Generiere einen Crystal Reports Bericht über den Mitarbeiter
        }
    }
    public class FastReportGeneratorService : ReportGeneratorService
    {
        public override void GenerateEmployeeReport(Employee employee)
        {
            //Generiere einen FastReport Bericht über den Mitarbeiter
        }
    }
}

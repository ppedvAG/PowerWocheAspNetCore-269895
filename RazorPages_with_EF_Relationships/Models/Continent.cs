using System.Diagnostics.Metrics;

namespace RazorPages_with_EF_Relationships.Models
{
    public class Continent
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation 1:N zu Country
        public ICollection<Country> Countries { get; set; }
    }
}

namespace RazorPages_with_EFCore_Relationships_LazyLoading.Models
{
    public class Continent
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Country>? Countries { get; set; } 
    }
}

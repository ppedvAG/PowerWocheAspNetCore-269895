namespace RazorPages_with_EFCore_Relationships_LazyLoading.Models
{
    public class Country
    {
        public int Id { get; set; }
        public int ContinentId { get; set; }
        public string Name { get; set; }

        
        public virtual Continent? ContinentRef { get; set; }
        public virtual ICollection<LanguageInCountry>? LanguagesInCountries { get; set; }
    }
}

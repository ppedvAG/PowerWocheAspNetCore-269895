namespace RazorPages_with_EFCore_Relationships.Models
{
    public class Country
    {
        public int Id { get; set; }
        public int ContinentId { get; set; }
        public string Name { get; set; }

        
        public Continent? ContinentRef { get; set; }
        public ICollection<LanguageInCountry>? LanguagesInCountries { get; set; }
    }
}

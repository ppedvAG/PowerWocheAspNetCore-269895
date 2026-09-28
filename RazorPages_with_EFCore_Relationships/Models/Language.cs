namespace RazorPages_with_EFCore_Relationships.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<LanguageInCountry>? LanguagesInCountries { get; set; }
    }
}

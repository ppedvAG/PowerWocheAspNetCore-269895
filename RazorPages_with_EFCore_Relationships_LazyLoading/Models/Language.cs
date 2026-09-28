namespace RazorPages_with_EFCore_Relationships_LazyLoading.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<LanguageInCountry>? LanguagesInCountries { get; set; }
    }
}

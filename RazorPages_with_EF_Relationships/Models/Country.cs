namespace RazorPages_with_EF_Relationships.Models
{
    public class Country
    {
        //PK
        public int Id { get; set; }
        public int ContinentId { get; set; }
        public string Name { get; set; }



        //Navigaion
        public Continent ContinentRef { get; set; }
        public ICollection<LanguageInCountry> LanguagesInCountries { get; set; }
    }
}

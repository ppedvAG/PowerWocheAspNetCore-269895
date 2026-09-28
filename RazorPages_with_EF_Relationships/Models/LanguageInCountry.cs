using System.ComponentModel;

namespace RazorPages_with_EF_Relationships.Models
{
    public class LanguageInCountry
    {
        public int Id { get; set; }

        public int CountryId { get; set; }
        public int LanguageId { get; set; }
        public int Percent { get; set; }

        //Navigation
        [DisplayName("Sprache")]
        public Language Language { get; set; }


        [DisplayName("Land")]
        public Country Country { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace RazorPages_mit_EFCore_Scaffolder.Models
{
    //POCO - Klasse (Entität)
    public class Movie
    {
        
        public int Id { get; set; }




        //Muss-Felder

        [Required]
        public string Title { get; set; }


        //Ist ein Mussfeld und darf 100Zeichen lang sein
        [MaxLength(100)]
        [Required]
        public string Description { get; set; }

        [Range(0, 50)]
        public decimal Price { get; set; }

        //Optionales Feld
        public int? Rating { get; set; }

        [Required (ErrorMessage = "Wann wurde der Film publiziert")]
        public int Year { get; set; }

        public bool? WinOscar { get; set; }


        [Required]
        public GenreType Genre { get; set; }

    }

    public enum GenreType { Action, Drama, Comedy, Thriller, Crime, Horror, Romance, ScienceFiction, Biography, Docu, Animation, Classics }

}

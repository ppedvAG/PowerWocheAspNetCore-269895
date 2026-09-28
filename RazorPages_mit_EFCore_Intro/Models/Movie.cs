namespace RazorPages_mit_EFCore_Intro.Models
{

    //POCO - Klasse (Entität)
    public class Movie
    {
        public int Id { get; set; }

        //Muss-Felder
        public string Title { get; set; }

        public string Description { get; set; }
        public decimal Price { get; set;  }

        //Optionales Feld
        public int? Rating { get; set;  }
        public int Year { get; set;  }

        public bool? WinOscar { get; set; }

        public GenreType Genre { get; set; }

    }

    public enum GenreType { Action, Drama, Comedy, Thriller, Crime, Horror, Romance, ScienceFiction, Biography, Docu, Animation, Classics }

}

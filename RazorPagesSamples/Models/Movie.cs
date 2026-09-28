namespace RazorPagesSamples.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int ReleaseYear { get; set; }
        public Genre Genre { get; set; }
    }

    public enum Genre
    {
        Drama,
        Komödie,
        Action,
        ScienceFiction,
        Dokumentation,
        Animation
    }
}

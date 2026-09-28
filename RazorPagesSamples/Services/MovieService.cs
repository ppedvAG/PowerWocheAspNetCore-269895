using RazorPagesSamples.Models;

namespace RazorPagesSamples.Services
{
    public class MovieService : IMovieService
    {

        private static readonly List<Movie> Movies =
        [
            new Movie { Id = 1, Title = "Inception", ReleaseYear = 2010, Genre = Genre.ScienceFiction },
            new Movie { Id = 2, Title = "The Dark Knight", ReleaseYear = 2008, Genre = Genre.Action },
            new Movie { Id = 3, Title = "Forrest Gump", ReleaseYear = 1994, Genre = Genre.Drama },
            new Movie { Id = 4, Title = "Alles steht Kopf", ReleaseYear = 2015, Genre = Genre.Animation }
        ];

        private static readonly object SyncRoot = new();

        public IReadOnlyList<Movie> GetMovies()
        {
            lock (SyncRoot)
            {
                // Eine Kopie verhindert, dass Razor Pages die interne Liste verändert.
                return Movies.Select(movie => Copy(movie)).ToList();
            }
        }

        public Movie? GetMovieById(int id)
        {
            lock (SyncRoot)
            {
                Movie? movie = Movies.FirstOrDefault(movie => movie.Id == id);
                return movie is null ? null : Copy(movie);
            }
        }

        public Movie AddMovie(string title, Genre genre, int releaseYear)
        {
            lock (SyncRoot)
            {
                int nextId = Movies.Count == 0 ? 1 : Movies.Max(movie => movie.Id) + 1;
                Movie movie = new()
                {
                    Id = nextId,
                    Title = title,
                    Genre = genre,
                    ReleaseYear = releaseYear
                };

                Movies.Add(movie);
                return Copy(movie);
            }
        }

        private static Movie Copy(Movie movie) => new()
        {
            Id = movie.Id,
            Title = movie.Title,
            ReleaseYear = movie.ReleaseYear,
            Genre = movie.Genre
        };
    }
}

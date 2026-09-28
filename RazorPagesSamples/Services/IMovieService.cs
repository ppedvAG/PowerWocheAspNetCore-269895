using RazorPagesSamples.Models;

namespace RazorPagesSamples.Services
{
    public interface IMovieService
    {
        IReadOnlyList<Movie> GetMovies();

        Movie? GetMovieById(int id);

        Movie AddMovie(string title, Genre genre, int releaseYear);
    }
}

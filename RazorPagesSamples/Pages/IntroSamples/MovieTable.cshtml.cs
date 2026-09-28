using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesSamples.Models;
using RazorPagesSamples.Services;

namespace RazorPagesSamples.Pages.IntroSamples
{
    public class MovieTableModel : PageModel
    {
        private readonly IMovieService _movieService;

        public IReadOnlyList<Movie> Movies { get; private set; } = [];

        public MovieTableModel(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public void OnGet()
        {
            Movies = _movieService.GetMovies();
        }
    }
}

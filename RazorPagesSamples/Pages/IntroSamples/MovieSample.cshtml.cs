using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesSamples.Models;
using RazorPagesSamples.Services;

namespace RazorPagesSamples.Pages.IntroSamples
{
    public class MovieSampleModel : PageModel
    {

        //Movie-Service
        private readonly IMovieService _movieService;


        //Datenstruktur, die an die Razor Page gebunden wird. Die Datenstruktur ist nur lesbar, da sie nur einen Getter hat.
        public Movie? Movie { get; private set; }

        public MovieSampleModel(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public void OnGet()
        {
            Movie = _movieService.GetMovieById(1);
        }
    }
}

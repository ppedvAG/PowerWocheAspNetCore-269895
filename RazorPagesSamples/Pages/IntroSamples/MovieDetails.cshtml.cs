using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesSamples.Models;
using RazorPagesSamples.Services;

namespace RazorPagesSamples.Pages.IntroSamples
{
    public class MovieDetailsModel : PageModel
    {
        private readonly IMovieService _movieService;

        public MovieDetailsModel(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public Movie? Movie { get; private set; }


        //
        public IActionResult OnGet(int id)
        {
            Movie = _movieService.GetMovieById(id);

            //Wenn der Film nicht gefunden wird, wird eine 404-Fehlerseite zurückgegeben.
            if (Movie is null)
            {
                return NotFound(); //404-Fehlerseite, wenn der Film nicht gefunden wird.
            }

            return Page(); //Response für unseren Browser. (Daten). 
        }
    }
}

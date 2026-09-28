using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StateManagement.Models;
using System.Text.Json;

namespace StateManagement.Pages
{
    public class SessionStartModel : PageModel
    {
        public void OnGet()
        {
            this.HttpContext.Session.SetInt32("Lottozahlen", 123123123);
            this.HttpContext.Session.SetString("email", "info@ppedv.de");

            Movie movie = new();
            movie.Id = 12;
            movie.Title = "Batman";
            movie.Description = "Harley Quinn ist mit Batman WG-Bewohner";
            movie.Price = 10;


            string json = JsonSerializer.Serialize(movie);
            this.HttpContext.Session.SetString("film", json);
        }
    }
}

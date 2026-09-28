namespace RazorPages_mit_EFCore_Intro.Data
{
    public static class DataSeeder
    {
        public static void SeedMovies(MovieDbContext ctx)
        {
            //Sind Filme in der Tabelle vorhanden, wenn nein, lege welche an
            if (!ctx.Movies.Any())
            {
                ctx.Movies.Add(new Models.Movie { Title = "Coda", Description = "Singtalent", Price = 19.99m, Year = 2021, Genre = Models.GenreType.Drama });
                ctx.Movies.Add(new Models.Movie { Title = "Jurassic Reverse Park", Description = "Dinos züchten Menschen", Price = 12.99m, Year = 2089, Genre = Models.GenreType.Action });
                ctx.Movies.Add(new Models.Movie { Title = "Batman Robin", Description = "Findet Joker", Price = 29.99m, Year = 2043, Genre = Models.GenreType.Action });

                //Umsetzunger der Datenbank
                ctx.SaveChanges();
            }
        }
    }
}

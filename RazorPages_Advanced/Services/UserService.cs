using RazorPages_Advanced.Models;

namespace RazorPages_Advanced.Services
{
    public class UserService : IUserService
    {
        public async Task<UserProfile> GetUserProfileAsync(int userId)
        {
            // Simulierte Daten für das Beispiel
            await Task.Delay(1000); // Simuliert eine asynchrone Operation
            return new UserProfile
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                Bio = "Software Developer"
            };
        }
    }
}

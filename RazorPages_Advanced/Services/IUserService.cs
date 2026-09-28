using RazorPages_Advanced.Models;

namespace RazorPages_Advanced.Services
{
    public interface IUserService
    {
        Task<UserProfile> GetUserProfileAsync(int userId);
    }
}

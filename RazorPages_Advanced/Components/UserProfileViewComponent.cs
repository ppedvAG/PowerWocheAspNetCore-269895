using Microsoft.AspNetCore.Mvc;
using RazorPages_Advanced.Models;
using RazorPages_Advanced.Services;

namespace RazorPages_Advanced.Components
{
    public class UserProfileViewComponent : ViewComponent
    {
        private readonly IUserService _userService;

        public UserProfileViewComponent(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int userId)
        {
            UserProfile userProfile = await _userService.GetUserProfileAsync(userId);
            return View("Default", userProfile);
        }
    }
}

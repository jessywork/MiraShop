using MiraShop.API.Models.ResponseModels;
using MiraShop.BLL.Interfaces;
using System.Security.Claims;

namespace MiraShop.API.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IUserService _userService;

        public CurrentUserService(IUserService userService)
        {
            _userService = userService;
        }

        public UserResponseModel? CurrentUser { get; private set; }

        public async Task AuthenticateUser(ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal != null && claimsPrincipal.Identity != null)
            {
                var isAuthenticated = claimsPrincipal.Identity.IsAuthenticated;

                if (isAuthenticated)
                {
                    CurrentUser = await SetCurrentUser(claimsPrincipal);
                }
            }
        }

        private async Task<UserResponseModel> SetCurrentUser(ClaimsPrincipal claimsPrincipal)
        {
            var emailClaim = claimsPrincipal.FindFirst(ClaimTypes.Email);

            if (emailClaim != null)
            {
                var userEmail = emailClaim.Value;

                var user = await _userService.GetUserByEmail(userEmail) ??
                        throw new InvalidOperationException("Unable to load user.");

                var authUser = new UserResponseModel()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.Name,
                    CartId = user.CartId,
                    FavListId = user.FavListId
                };

                return authUser;
            }

            throw new InvalidOperationException("Email claim not found.");
        }
    }
}

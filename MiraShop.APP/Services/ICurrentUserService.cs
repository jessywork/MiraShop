using MiraShop.API.Models.ResponseModels;
using System.Security.Claims;

namespace MiraShop.API.Services
{
    public interface ICurrentUserService
    {
        UserResponseModel? CurrentUser { get; }
        Task AuthenticateUser(ClaimsPrincipal claimsPrincipal);
    }
}

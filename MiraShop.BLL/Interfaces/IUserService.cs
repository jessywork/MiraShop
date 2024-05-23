using MiraShop.DAL.Filters;
using MiraShop.DAL.Models;

namespace MiraShop.BLL.Interfaces
{
    public interface IUserService : IEntitiesService<User, BaseSearchModel<User>>
    {
        Task<User?> GetUserByEmail(string Email);
        Task<Guid> GetUserDefaultHouseId(Guid userId);
    }
}

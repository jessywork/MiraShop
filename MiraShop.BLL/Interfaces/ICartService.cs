using MiraShop.DAL.Filters;
using MiraShop.DAL.Models;

namespace MiraShop.BLL.Interfaces
{
    public interface ICartService : IEntitiesService<Cart, BaseSearchModel<Cart>>
    {
        // Task<List<User>> GetUsersFromHouse(Guid houseId);
        // Task InsertWithUser(House house, Guid userId, CancellationTokenSource? token = null);
        // Task InsertUserToHouse(Guid houseId, Guid userId, CancellationTokenSource? token = null);
        // Task DeleteUsersFromHouse(Guid houseId, HashSet<Guid> usersId, bool forceDeleteHouse, CancellationTokenSource? token = null);
    }
}

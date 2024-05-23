using MiraShop.DAL.Filters;
using MiraShop.DAL.Models;

namespace MiraShop.BLL.Interfaces
{
    public interface IOrderService : IEntitiesService<Order, BaseSearchModel<Order>>
    {
        // Task<User?> GetUserByEmail(string Email);
        // Task<Guid> GetUserDefaultHouseId(Guid userId);
    }
}

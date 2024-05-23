using MiraShop.DAL.Filters;
using MiraShop.DAL.Models;

namespace MiraShop.BLL.Interfaces
{
    public interface IProductService : IEntitiesService<Product, BaseSearchModel<Product>>
    {
        // Task<User?> GetUserByEmail(string Email);
        // Task<Guid> GetUserDefaultHouseId(Guid userId);
    }
}

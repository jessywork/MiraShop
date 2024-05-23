using MiraShop.DAL.Filters;
using MiraShop.DAL.Models;

namespace MiraShop.BLL.Interfaces
{
    public interface ICategoryService : IEntitiesService<Category, BaseSearchModel<Category>>
    {
        // Task AddProductsToInventory(Guid id, Dictionary<Guid, InventoryProduct> inventoryProducts, CancellationTokenSource? token = null);
        // Task ChangeDefaultInventory(Guid newDefaultId);
    }
}

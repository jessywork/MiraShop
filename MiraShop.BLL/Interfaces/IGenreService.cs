using MiraShop.DAL.Filters;
using MiraShop.DAL.Models;

namespace MiraShop.BLL.Interfaces
{
    public interface IGenreService : IEntitiesService<Genre, BaseSearchModelWithHouse<Genre>>
    {
        // Task<Dictionary<Product, int>> GetProductsFromShoppingList(Guid shoppingListId);
        // Task AddProductsToShoppingList(Guid id, Dictionary<Guid, ShoppingListProduct> shoppingListProducts, CancellationTokenSource? token = null);
        // Task ChangeDefaultShoppingList(Guid newDefaultId);
    }
}

using MiraShop.DAL.Filters;
using MiraShop.DAL.Models;

namespace MiraShop.BLL.Interfaces
{
    public interface IFavListService : IEntitiesService<FavList, BaseSearchModel<FavList>>
    {
        Task<IEnumerable<Product>> GetProductsFromFavList(Guid favListId);
        Task UpdateProductToFavList(Guid id, FavListProduct favListProduct, CancellationTokenSource? token = null);
    }
}

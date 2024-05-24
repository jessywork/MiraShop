using MiraShop.DAL.Filters;
using MiraShop.DAL.Models;

namespace MiraShop.BLL.Interfaces
{
    public interface ICartService : IEntitiesService<Cart, BaseSearchModel<Cart>>
    {
        Task<Dictionary<Product, int>> GetProductsFromFavList(Guid cartId);
        Task AddProductsToCart(Guid id, Dictionary<Guid, CartProduct> cartProducts, CancellationTokenSource? token = null)
    }
}

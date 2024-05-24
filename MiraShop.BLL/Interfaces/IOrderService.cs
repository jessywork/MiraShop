using MiraShop.DAL.Filters;
using MiraShop.DAL.Models;

namespace MiraShop.BLL.Interfaces
{
    public interface IOrderService : IEntitiesService<Order, BaseSearchModel<Order>>
    {
        Task<Dictionary<Product, int>> GetProductsFromOrder(Guid orderId);
    }
}

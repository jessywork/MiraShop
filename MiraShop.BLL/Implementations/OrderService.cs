using MiraShop.BLL.Data.Consts.ENConsts;
using MiraShop.BLL.Interfaces;
using MiraShop.DAL.Exceptions;
using MiraShop.DAL.Filters;
using MiraShop.DAL.Models;
using MiraShop.DAL.Repositories.Interfaces;

namespace MiraShop.BLL.Implementations
{
    public class OrderService : EntitiesService<Order, BaseSearchModel<Order>>, IOrderService
    {
        protected override string entityName { get; set; } = GenericConsts.Entities.Order;

        private readonly IRepository<OrderProduct> _orderProductRepository;

        public OrderService(IRepository<Order> orderRepository, IRepository<OrderProduct> orderProductRepository) : base(orderRepository)
        {
            _orderProductRepository = orderProductRepository;
        }

        /// <summary>
        /// Get all the products in the orde with quantities.
        /// </summary>
        /// <param name="id">Order Id</param>
        public async Task<Dictionary<Product, int>> GetProductsFromOrder(Guid orderId)
        {
            var products = await _orderProductRepository.GetWhere<Product>(productList =>
                productList.OrderId == orderId, productList => productList.Product!);

            if (products == null || products.Count == 0)
            {
                throw new NotFoundException(GenericConsts.Exceptions.NoProductsFoundInOrder);
            }

            var productQuantities = new Dictionary<Product, int>();

            foreach (var product in products)
            {
                if (productQuantities.ContainsKey(product))
                {
                    productQuantities[product]++;
                }
                else
                {
                    productQuantities.Add(product, 1);
                }
            }

            return productQuantities;
        }
    }
}

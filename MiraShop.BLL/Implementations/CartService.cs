using MiraShop.BLL.Data.Consts.ENConsts;
using MiraShop.BLL.Interfaces;
using MiraShop.DAL.Exceptions;
using MiraShop.DAL.Filters;
using MiraShop.DAL.Models;
using MiraShop.DAL.Repositories.Interfaces;

namespace MiraShop.BLL.Implementations
{
    public class CartService : EntitiesService<Cart, BaseSearchModel<Cart>>, ICartService
    {
        protected override string entityName { get; set; } = GenericConsts.Entities.Cart;

        private readonly IRepository<CartProduct> _cartProductRepository;

        public CartService(IRepository<Cart> cartRepository, IRepository<CartProduct> cartProductRepository) : base(cartRepository)
        {
            _cartProductRepository = cartProductRepository;
        }

        /// <summary>
        /// Get all the products added to the cart with quantities.
        /// </summary>
        /// <param name="id">Cart Id</param>
        public async Task<Dictionary<Product, int>> GetProductsFromFavList(Guid cartId)
        {
            var products = await _cartProductRepository.GetWhere<Product>(productList =>
                productList.CartId == cartId, productList => productList.Product!);

            if (products == null || products.Count == 0)
            {
                throw new NotFoundException(GenericConsts.Exceptions.NoProductsFoundInCart);
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

        /// <summary>
        /// Update the quantity of the products in the cart.
        /// Update the quantity of the products that already exist in the cart.
        /// Insert the products that don't exist in the cart.
        /// </summary>
        /// <param name="id">Cart Id</param>
        /// <param name="cartProducts">Products to insert or update in the cart</param>
        public async Task AddProductsToCart(Guid id, Dictionary<Guid, CartProduct> cartProducts, CancellationTokenSource? token = null)
        {
            var productsToUpdate = await _cartProductRepository.GetWhere(
                x => x.CartId == id && cartProducts.Keys.Contains(x.ProductId));

            foreach (var entity in productsToUpdate)
            {
                entity.Quantity += cartProducts[entity.ProductId].Quantity;

                await _cartProductRepository.Update(entity, false, token);
            }

            if (productsToUpdate.ToList().Count < cartProducts.Count)
            {
                var productsToInsert = cartProducts
                    .Where(pair => !productsToUpdate.Any(entity => entity.ProductId == pair.Key))
                    .Select(pair => pair.Value);

                await _cartProductRepository.InsertMultiple(productsToInsert, false, token);
            }

            await _cartProductRepository.SaveChangesAsync(token);
        }
    }
}

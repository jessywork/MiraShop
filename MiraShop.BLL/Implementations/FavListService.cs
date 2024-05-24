using MiraShop.BLL.Data.Consts.ENConsts;
using MiraShop.BLL.Interfaces;
using MiraShop.DAL.Exceptions;
using MiraShop.DAL.Filters;
using MiraShop.DAL.Models;
using MiraShop.DAL.Repositories.Interfaces;

namespace MiraShop.BLL.Implementations
{
    public class FavListService : EntitiesService<FavList, BaseSearchModel<FavList>>, IFavListService
    {
        protected override string entityName { get; set; } = GenericConsts.Entities.FavList;

        private readonly IRepository<FavListProduct> _favListProductRepository;

        public FavListService(IRepository<FavList> favListRepository, IRepository<FavListProduct> favListProductRepository) : base(favListRepository)
        {
            _favListProductRepository = favListProductRepository;
        }

        /// <summary>
        /// Get all the products added to the favorites list.
        /// </summary>
        /// <param name="id">FavList Id</param>
        public async Task<IEnumerable<Product>> GetProductsFromFavList(Guid favListId)
        {
            var products = await _favListProductRepository.GetWhere<Product>(productList =>
                productList.FavListId == favListId, productList => productList.Product!);

            if (products == null || products.Count == 0)
            {
                throw new NotFoundException(GenericConsts.Exceptions.NoProductsFoundInFavList);
            }

            return products;
        }

        /// <summary>
        /// Insert the product that don't exist in the favorites list.
        /// Remove the product that exist in the favorites list.
        /// </summary>
        /// <param name="id">FavList Id</param>
        /// <param name="favListProduct">Product to insert or remove in the favorites list</param>
        public async Task UpdateProductToFavList(Guid id, FavListProduct favListProduct, CancellationTokenSource? token = null)
        {
            var existingProduct = await _favListProductRepository.GetSingleWhere(
                x => x.FavListId == id && x.ProductId == favListProduct.ProductId);

            if (existingProduct != null)
            {
                await _favListProductRepository.Delete(existingProduct, token);
            }
            else
            {
                await _favListProductRepository.Insert(favListProduct, token);
            }

            await _favListProductRepository.SaveChangesAsync(token);
        }
    }
}

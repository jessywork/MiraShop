using MiraShop.BLL.Data.Consts.ENConsts;
using MiraShop.BLL.Interfaces;
using MiraShop.DAL.Filters;
using MiraShop.DAL.Models;
using MiraShop.DAL.Repositories.Interfaces;

namespace MiraShop.BLL.Implementations
{
    public class ProductService : EntitiesService<Product, BaseSearchModel<Product>>, IProductService
    {
        protected override string entityName { get; set; } = GenericConsts.Entities.Product;

        public ProductService(IRepository<Product> repository) : base(repository)
        {
        }
    }
}

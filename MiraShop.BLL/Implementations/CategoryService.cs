using MiraShop.BLL.Data.Consts.ENConsts;
using MiraShop.BLL.Interfaces;
using MiraShop.DAL.Filters;
using MiraShop.DAL.Models;
using MiraShop.DAL.Repositories.Interfaces;

namespace MiraShop.BLL.Implementations
{
    public class CategoryService : EntitiesService<Category, BaseSearchModel<Category>>, ICategoryService
    {
        protected override string entityName { get; set; } = GenericConsts.Entities.Category;

        public CategoryService(IRepository<Category> repository) : base(repository)
        {
        }
    }
}

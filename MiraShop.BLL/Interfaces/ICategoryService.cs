using MiraShop.DAL.Filters;
using MiraShop.DAL.Models;

namespace MiraShop.BLL.Interfaces
{
    public interface ICategoryService : IEntitiesService<Category, BaseSearchModel<Category>>
    {
    }
}

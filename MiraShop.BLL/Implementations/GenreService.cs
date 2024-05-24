using MiraShop.BLL.Data.Consts.ENConsts;
using MiraShop.BLL.Interfaces;
using MiraShop.DAL.Filters;
using MiraShop.DAL.Models;
using MiraShop.DAL.Repositories.Interfaces;

namespace MiraShop.BLL.Implementations
{
    public class GenreService : EntitiesService<Genre, BaseSearchModel<Genre>>, IGenreService
    {
        protected override string entityName { get; set; } = GenericConsts.Entities.Genre;

        public GenreService(IRepository<Genre> repository) : base(repository)
        {
        }
    }
}

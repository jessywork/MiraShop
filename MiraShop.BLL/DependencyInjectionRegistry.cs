using Microsoft.Extensions.DependencyInjection;
using MiraShop.BLL.Implementations;
using MiraShop.BLL.Interfaces;

namespace MiraShop.BLL
{
    public static class DependencyInjectionRegistry
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IEntitiesService<,>), typeof(EntitiesService<,>));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IFavListService, FavListService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductService, ProductService>();
        }
    }
}

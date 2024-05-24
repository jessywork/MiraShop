using MiraShop.BLL.Interfaces;
using MiraShop.DAL.Exceptions;
using MiraShop.DAL.Filters;
using MiraShop.DAL.Models;
using MiraShop.DAL.Repositories.Interfaces;

namespace MiraShop.BLL.Implementations
{
    public class UserService : EntitiesService<User, BaseSearchModel<User>>, IUserService
    {
        private readonly ICartService _cartService;
        private readonly IFavListService _favListService;

        public UserService(IRepository<User> repository, ICartService cartService, IFavListService favListService) : base(repository)
        {
            _cartService = cartService;
            _favListService = favListService;
        }

        protected override async Task<bool> Validate(User user)
        {
            if (await repository.AnyWhere(b => b.Email == user.Email && b.Id != user.Id))
            {
                throw new EmailExistsException();
            }

            return true;
        }

        protected override async Task FinishInsert(User user)
        {
            Cart cart = new Cart()
            {
                UserId = user.Id
            };

            FavList favList = new FavList()
            {
                UserId = user.Id
            };

            await _cartService.Insert(cart);

            await _favListService.Insert(favList);
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await repository.GetSingleWhere(b => b.Email == email);
        }
    }
}

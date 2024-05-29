using AutoMapper;
using GrocifyApp.API.Models.ResponseModels;
using MiraShop.API.Models.RequestModels;
using MiraShop.API.Models.ResponseModels;
using MiraShop.DAL.Models;

namespace MiraShop.API.Models.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CartRequestModel, Cart>().ReverseMap();
            CreateMap<CartResponseModel, Cart>().ReverseMap();
            CreateMap<CartProductRequestModel, CartProduct>().ReverseMap();
            CreateMap<CartProductResponseModel, CartProduct>().ReverseMap();
            CreateMap<CategoryRequestModel, Category>().ReverseMap();
            CreateMap<CategoryResponseModel, Category>().ReverseMap();
            CreateMap<FavListRequestModel, FavList>().ReverseMap();
            CreateMap<FavListResponseModel, FavList>().ReverseMap();
            CreateMap<FavListProductRequestModel, FavListProduct>().ReverseMap();
            CreateMap<FavListProductResponseModel, FavListProduct>().ReverseMap();
            CreateMap<GenreRequestModel, User>().ReverseMap();
            CreateMap<OrderRequestModel, Order>().ReverseMap();
            CreateMap<OrderResponseModel, Order>().ReverseMap();
            CreateMap<OrderProductRequestModel, OrderProduct>().ReverseMap();
            CreateMap<OrderProductResponseModel, OrderProduct>().ReverseMap();
            CreateMap<ProductRequestModel, Product>().ReverseMap();
            CreateMap<ProductResponseModel, Product>().ReverseMap();
            CreateMap<UserResponseModel, User>().ReverseMap();
            CreateMap<UserRequestModel, User>().ReverseMap();
        }
    }
}

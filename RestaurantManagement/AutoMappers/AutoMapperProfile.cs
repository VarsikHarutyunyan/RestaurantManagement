using AutoMapper;
using RestaurantManagement.Data.Entities;
using RestaurantManagement.Shared.Models;

namespace RestaurantManagement.Api.AutoMappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserCreateModel, User>().ReverseMap();
            CreateMap<UserModel, User>().ReverseMap();

            CreateMap<MenuCreateModel, Menu>().ReverseMap();
            CreateMap<MenuModel, Menu>().ReverseMap();

            CreateMap<ProductCreateModel, Product>().ReverseMap();
            CreateMap<ProductModel, Product>().ReverseMap();

            CreateMap<CategoryCreateModel, Category>().ReverseMap();
            CreateMap<CategoryModel, Category>().ReverseMap();

            CreateMap<OrderCreateModel, Order>().ReverseMap();
            CreateMap<OrderModel, Order>().ReverseMap();
        }
    }
}

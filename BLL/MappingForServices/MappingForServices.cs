using AutoMapper;
using BLL.AllDtos;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.MappingForServices
{
    public class MappingForServices : Profile
    {

        public MappingForServices()
        {
            CreateMap<User , UserDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
            CreateMap<Address, AddAddressDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<CreditCard, CreditCardDto>().ReverseMap();
            CreateMap<CreditCard, AddCreditCardDto>().ReverseMap();
            CreateMap<User, UserProfileDto>().ReverseMap();
            CreateMap<User, GetAllUsersDto>().ReverseMap();



            CreateMap<Favorite, FavoriteDto>().ReverseMap();



            CreateMap<Basket, BasketDto>().ReverseMap();




            CreateMap<Comment, CommentDto>().ReverseMap();





            CreateMap<Category, CategoryDto>().ReverseMap();


            CreateMap<Product, ProductDto>().ReverseMap();
            
            CreateMap<Brand, BrandDto>().ReverseMap();










        }

    }
}

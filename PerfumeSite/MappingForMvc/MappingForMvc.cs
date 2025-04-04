using AutoMapper;
using BLL.AllDtos;
using DAL.Entities;
using PerfumeSite.AddressViewModels;
using PerfumeSite.BrandViewModels;
using PerfumeSite.CategoryViewModels;
using PerfumeSite.CommentViewModels;
using PerfumeSite.CreditCardViewModels;
using PerfumeSite.FavoriteViewModels;
using PerfumeSite.ProductViewModels;
using PerfumeSite.UserViewModels;

namespace PerfumeSite.MappingForMvc
{
    public class MappingForMvc : Profile
    {

        public MappingForMvc()
        {
            CreateMap<UserLoginDto, UserLoginViewModel>().ReverseMap();
            CreateMap<UserDto, UserViewModel>().ReverseMap();


            CreateMap<AddAddressDto, AddAddressViewModel>().ReverseMap();
            CreateMap<AddressDto, AddressViewModel>().ReverseMap();
            CreateMap<Address, AddressViewModel>().ReverseMap();
            CreateMap<UserProfileDto, UserProfileViewModel>().ReverseMap();



            CreateMap<FavoriteDto, FavoriteViewModel>().ReverseMap();









            CreateMap<CommentDto, CommentViewModel>().ReverseMap();






            CreateMap<AddCreditCardDto, AddCreditCardViewModel>().ReverseMap();
            CreateMap<CreditCardDto, CreditCardViewModel>().ReverseMap();


            CreateMap<ProductViewModel, ProductDto>().ReverseMap();
       

            CreateMap<GetAllUsersDto, GetAllUsersViewModel>().ReverseMap();




            CreateMap<CategoryDto, AddCategoryViewModel>().ReverseMap();
            CreateMap<BrandDto, AddBrandViewModel>().ReverseMap();









        }

    }
}

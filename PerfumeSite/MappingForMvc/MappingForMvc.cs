using AutoMapper;
using BLL.AllDtos;
using DAL.Entities;
using PerfumeSite.AddressViewModels;
using PerfumeSite.CreditCardViewModels;
using PerfumeSite.UserViewModels;

namespace PerfumeSite.MappingForMvc
{
    public class MappingForMvc : Profile
    {

        public MappingForMvc()
        {
            CreateMap<UserLoginDto, UserLoginViewModel>().ReverseMap();
            CreateMap<UserDto, UserViewModel>().ReverseMap();
            CreateMap<UserListDto, UserListViewModel>().ReverseMap(); 

            CreateMap<AddAddressDto, AddAddressViewModel>().ReverseMap();
            CreateMap<AddressDto, AddressViewModel>().ReverseMap();
            CreateMap<Address, AddressViewModel>().ReverseMap();


            CreateMap<AddCreditCardDto, AddCreditCardViewModel>().ReverseMap();
            CreateMap<CreditCardDto, CreditCardViewModel>().ReverseMap();








        }

    }
}

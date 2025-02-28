using AutoMapper;
using BLL.AllDtos;
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
            CreateMap<AddAddressDto, AddAddressViewModel>().ReverseMap();
            CreateMap<AddressDto, AddressViewModel>().ReverseMap();
            CreateMap<CreditCardDto, CreditCardViewModel>().ReverseMap();
            CreateMap<AddCreditCardDto, AddCreditCardViewModel>().ReverseMap();







        }

    }
}

using AutoMapper;
using BLL.AllDtos;
using PerfumeSite.UserViewModels;

namespace PerfumeSite.MappingForMvc
{
    public class MappingForMvc : Profile
    {

        public MappingForMvc()
        {
            CreateMap<UserLoginDto, UserLoginViewModel>().ReverseMap();
            CreateMap<UserDto, UserViewModel>().ReverseMap();
          

        }

    }
}

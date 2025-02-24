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
        }

    }
}

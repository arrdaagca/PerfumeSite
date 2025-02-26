using AutoMapper;
using BLL.AbstractServices;
using BLL.AllDtos;
using DAL.AbstractRepositories;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ConcreteServices
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _genericRepository;
        private readonly IMapper _mapper;

        public UserService(IGenericRepository<User> genericRepository,IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public UserDto GetByEmail(string email)
        {
            var user = _genericRepository.GetAll().FirstOrDefault(x => x.Email == email);
            return _mapper.Map<UserDto>(user);
        }

        public UserDto GetById(int id)
        {
            var user = _genericRepository.GetById(id);
            return _mapper.Map<UserDto>(user);
        }

        public UserDto Login(UserLoginDto userLoginDto)
        {
            var loggedInUser = _genericRepository.GetAll().FirstOrDefault(x => x.Email == userLoginDto.Email && x.Password == userLoginDto.Password);

            return _mapper.Map<UserDto>(loggedInUser);  
        }

        public void SignUp(UserDto userDto)
        {
            _genericRepository.Add(_mapper.Map<User>(userDto));
        }

        public void UpdatePassword(UserDto userDto)
        {
           var user = _genericRepository.GetById(userDto.Id);
            user.Password = userDto.Password;
            _genericRepository.Update(user);
        }
        public UserDto GetLoggedInUser(int? userId)
        {
            var user = _genericRepository.GetById((int)userId);

            return _mapper.Map<UserDto>(user);
        }

       
    }
}

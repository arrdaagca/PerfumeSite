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
using System.Security.Cryptography;
using BLL.Helpers;
using System.Threading.Channels;

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
            // Kullanıcı adı veya e-posta ile kullanıcıyı bul
            var loggedInUser = _genericRepository.GetAll().FirstOrDefault(x => x.Email == userLoginDto.Email);



            // Kullanıcı var mı kontrol et
            if (loggedInUser == null || !BCrypt.Net.BCrypt.Verify(userLoginDto.Password, loggedInUser.Password))
            {
                return null; // Kullanıcı yoksa veya şifre yanlışsa null dön
            }

            return _mapper.Map<UserDto>(loggedInUser);
        }


            



        public void SignUp(UserDto userDto)
        {
            userDto.Password = SecurityHelper.HashPassword(userDto.Password);

            _genericRepository.Add(_mapper.Map<User>(userDto));
        }

        public UserDto GetLoggedInUser(int? userId)
        {
            var user = _genericRepository.GetById((int)userId);

            return _mapper.Map<UserDto>(user);
        }

       
        public UserDto GetByPhoneNumber(string phoneNumber)
        {
            var user = _genericRepository.GetAll().FirstOrDefault(x => x.PhoneNumber == phoneNumber);
            return _mapper.Map<UserDto>(user);
        }

        public void UpdatePasswordWithOutCheck(UserDto userDto)
        {
           var user = _genericRepository.GetById(userDto.Id);
            
            user.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

            _genericRepository.Update(user);
        }

        public UserProfileDto GetUserProfile(int id)
        {
            var findGetUser = _genericRepository.GetById(id);


            return _mapper.Map<UserProfileDto>(findGetUser);

        }

        public void UpdateUserProfile(UserProfileDto userProfileDto)
        {
            var findUpdateUser = _genericRepository.GetById(userProfileDto.Id);

            var updateUser = _mapper.Map(userProfileDto, findUpdateUser);

            _genericRepository.Update(updateUser);

        }

        public void UpdatePasswordWithCheck(UserUpdatePasswordDto userUpdatePasswordDto)
        {
            var findUpdateUser = _genericRepository.GetById(userUpdatePasswordDto.Id);


            findUpdateUser.Password = BCrypt.Net.BCrypt.HashPassword(userUpdatePasswordDto.NewPassword);

            _genericRepository.Update(findUpdateUser);


        }

        public UserDto GetByUserName(string userName)
        {
            var getByUsername = _genericRepository.GetAll().FirstOrDefault(x => x.UserName == userName);
            return _mapper.Map<UserDto>(getByUsername);
        }

        public List<GetAllUsersDto> GetAllUsers()
        {
            var getAllUsers = _genericRepository.GetAll().Where(x=>x.IsAdmin == false);

            return _mapper.Map<List<GetAllUsersDto>>(getAllUsers);

        }
    }
}

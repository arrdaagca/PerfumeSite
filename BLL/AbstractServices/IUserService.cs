using BLL.AllDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AbstractServices
{
    public interface IUserService
    {

        void SignUp(UserDto userDto);

        UserDto Login(UserLoginDto userLoginDto);
        
        UserDto GetByEmail(string email);
        UserDto GetByUserName(string userName);
        UserDto GetById(int id);
        UserDto GetLoggedInUser(int? userId);
        void UpdatePasswordWithOutCheck(UserDto userDto);

        UserProfileDto GetUserProfile(int id);

        void UpdateUserProfile(UserProfileDto userProfileDto);


        void UpdatePasswordWithCheck(UserUpdatePasswordDto userUpdatePasswordDto);


        UserDto GetByPhoneNumber(string phoneNumber);



    }
}

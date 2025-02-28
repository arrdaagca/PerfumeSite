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
        
        List<UserListDto> GetUsers();
        UserDto GetByEmail(string email);
        UserDto GetById(int id);
        UserDto GetLoggedInUser(int? userId);
        void UpdatePassword(UserDto userDto);

        


    }
}

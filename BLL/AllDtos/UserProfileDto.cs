using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AllDtos
{
    public class UserProfileDto : BaseDto
    {


        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }

    }
}

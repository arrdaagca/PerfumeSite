﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AllDtos
{
    public class UserDto : BaseDto
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public string UserName { get; set; }

        public string PhoneNumber{ get; set; }
        
        public bool IsAdmin { get; set; }
    }
}

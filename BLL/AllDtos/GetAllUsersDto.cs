﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AllDtos
{
    public class GetAllUsersDto : BaseDto
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}

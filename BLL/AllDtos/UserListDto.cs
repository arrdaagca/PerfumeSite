using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AllDtos
{
    public class UserListDto : BaseDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;



    }
}

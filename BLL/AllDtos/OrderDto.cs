using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AllDtos
{
    public class OrderDto : BaseDto
    {

        public int UserId { get; set; }
        public UserDto User { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }

        public int AddressId { get; set; }
        public AddressDto Address { get; set; }
        public int CreditCardId { get; set; }
        public CreditCardDto CreditCard { get; set; }
        public int Quantity { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;


    }
}

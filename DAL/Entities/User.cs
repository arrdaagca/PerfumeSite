﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class User : BaseClass
    {

        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsAdmin { get; set; }
        public List<Address> Addresses { get; set; }
        public List<CreditCard> CreditCards { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();

        public List<Favorite> Favorites { get; set; } = new List<Favorite>();

        public List<Basket> Baskets { get; set; } = new List<Basket>();

        public List<Order> Orders { get; set; } = new List<Order>();






    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Address : BaseClass
    {

        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Neighbourhood { get; set; }
        public string Street { get; set; }
        public int BuildingNumber { get; set; }
        public int DoorNumber { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();



    }
}

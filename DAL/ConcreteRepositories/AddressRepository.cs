using DAL.AbstractRepositories;
using DAL.Data;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ConcreteRepositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _context;

        public AddressRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Address> GetAddressByUserId(int? userId)
        {
            var userAddresses = new List<Address>();    



            var address = _context.Addresses.Where(a => a.UserId == userId).ToList();
            return address;


        }
    }
}

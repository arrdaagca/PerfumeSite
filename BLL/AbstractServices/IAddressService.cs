using BLL.AllDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AbstractServices
{
    public interface IAddressService
    {

        void AddAddress(AddAddressDto addAddressDto); 
        List<AddressDto> GetAddressByUserId(int? userId);
        void DeleteAddress(int id);


        void EditAddress(AddressDto addressDto);




    }
}

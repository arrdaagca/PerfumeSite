using BLL.AllDtos;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AbstractServices
{
    public interface IAddressService
    {

        void AddAddress(AddressDto addressDto);


       Address GetUserAddress(int userId);



    }
}

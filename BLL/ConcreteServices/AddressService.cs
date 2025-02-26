using AutoMapper;
using BLL.AbstractServices;
using BLL.AllDtos;
using DAL.AbstractRepositories;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ConcreteServices
{
    public class AddressService : IAddressService
    {
        private readonly IGenericRepository<Address> _genericRepository;
        private readonly IMapper _mapper;

        public AddressService(IGenericRepository<Address> genericRepository,IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }


        public void AddAddress(AddressDto addressDto)
        {

         

            _genericRepository.Add(_mapper.Map<Address>(addressDto));
        }

        public Address GetUserAddress(int userId)
        {
            var userAddress =  _genericRepository.GetAll().FirstOrDefault(a => a.UserId == userId);


            return _mapper.Map<Address>(userAddress);   
        }
    }
}

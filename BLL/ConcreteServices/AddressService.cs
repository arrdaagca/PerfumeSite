using AutoMapper;
using BLL.AbstractServices;
using BLL.AllDtos;
using DAL.AbstractRepositories;
using DAL.Entities;
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
        private readonly IAddressRepository _addressRepository;

        public AddressService(IGenericRepository<Address> genericRepository,IMapper mapper,IAddressRepository addressRepository)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _addressRepository = addressRepository;
        }

        public void AddAddress(AddAddressDto addAddressDto)
        {
             _genericRepository.Add(_mapper.Map<Address>(addAddressDto));
          
        }

        public List<AddressDto> GetAddressByUserId(int? userId)
        {
            var addresses = _addressRepository.GetAddressByUserId(userId);  
            return _mapper.Map<List<AddressDto>>(addresses);    
        }
    }
}

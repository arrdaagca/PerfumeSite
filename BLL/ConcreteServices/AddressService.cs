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

        public AddressService(IGenericRepository<Address> genericRepository,IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public void AddAddress(AddAddressDto addAddressDto)
        {
             _genericRepository.Add(_mapper.Map<Address>(addAddressDto));
          
        }

        public List<AddressDto> GetAddressByUserId(int? userId)
        {
            var addresses = _genericRepository.GetAll().Where(x => x.UserId == userId).ToList();
            return _mapper.Map<List<AddressDto>>(addresses);    
        }
    }
}

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
    public class BrandService : IBrandService
    {
        private readonly IGenericRepository<Brand> _genericRepository;
        private readonly IMapper _mapper;

        public BrandService(IGenericRepository<Brand> genericRepository,IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public void AddBrand(BrandDto addBrandDto)
        {
           _genericRepository.Add(_mapper.Map<Brand>(addBrandDto));
        }

      

        public List<BrandDto> GetAllBrands()
        {
            var brands = _genericRepository.GetAll(); 

            var brandDtos = _mapper.Map<List<BrandDto>>(brands); 

            return brandDtos; 
        }

        public BrandDto GetById(int id)
        {
           var brand = _genericRepository.GetById(id);
            return _mapper.Map<BrandDto>(brand);
        }

        public void UpdateBrand(BrandDto brandDto)
        {
            var updateBrand = _genericRepository.GetById(brandDto.Id);
            _mapper.Map(brandDto, updateBrand);
            _genericRepository.Update(updateBrand);
        }
    }
}

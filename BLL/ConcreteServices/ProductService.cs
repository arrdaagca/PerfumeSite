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
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _genericRepository;
        private readonly IMapper _mapper;

        public ProductService(IGenericRepository<Product> genericRepository,IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public void AddProduct(ProductDto addProductDto)
        {
            _genericRepository.Add(_mapper.Map<Product>(addProductDto));
        }

        public void DeleteById(int id)
        {
            
            _genericRepository.DeleteById(id);
        }

        public List<ProductDto> GetAllProducts()
        {
            var getAllProducts = _genericRepository.GetAll();
            var products = _mapper.Map<List<ProductDto>>(getAllProducts);
            return products;
        }

        public ProductDto GetById(int id)
        {
            var getProductById = _genericRepository.GetById(id);
            return _mapper.Map<ProductDto>(getProductById);
        }

        public void UpdateProduct(ProductDto productDto)
        {
            var updateProduct = _genericRepository.GetById(productDto.Id);

            _mapper.Map(productDto, updateProduct);

            _genericRepository.Update(updateProduct);

        }
    }
}

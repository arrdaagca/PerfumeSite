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
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _genericRepository;
        private readonly IMapper _mapper;

        public CategoryService(IGenericRepository<Category> genericRepository,IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public void AddCategory(CategoryDto addCategoryDto)
        {
            _genericRepository.Add(_mapper.Map<Category>(addCategoryDto));
        }

        public List<CategoryDto> GetAllCategories()
        {
           var allCategories = _genericRepository.GetAll();

            var categories = _mapper.Map<List<CategoryDto>>(allCategories);
            return categories;

        }


      
    }
}
